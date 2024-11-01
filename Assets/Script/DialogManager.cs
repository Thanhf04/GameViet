using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public Image CharacterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;
    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;

      void Awake() {
        if (Instance == null) {
            Instance = this;}
    }

    void Start() {
        lines = new Queue<DialogueLine>();
    }
    

    public void StartDialogue(Dialogue dialogue){
        isDialogueActive = true;
        lines.Clear();
        foreach(DialogueLine dialogueLine in dialogue.dialogueLines){
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue(){
        if(lines.Count == 0){
            EndDialogue();
            return;
        }
        DialogueLine currentLine = lines.Dequeue();
        CharacterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines(); 
        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine){
        dialogueArea.text = "";
        foreach(char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    void EndDialogue(){
        isDialogueActive = false;

    }
}
