using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialoguesText;
    public string[] dialogue;
    private int index;

    public GameObject contBtn;
    public float wordSpeed;
    public bool playerIsClose;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
            if(dialoguePanel.activeInHierarchy){
                zeroText();
            }else{
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialoguesText.text == dialogue[index]){
            contBtn.SetActive(true);
        }
    }

    public void zeroText(){
        dialoguesText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(){
        foreach( char letter in dialogue[index].ToCharArray()){
            dialoguesText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void nextLine(){

        contBtn.SetActive(false);

        if(index < dialogue.Length -1){
            index++;
            dialoguesText.text ="";
            StartCoroutine(Typing());
        }else{
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            playerIsClose = false;
            zeroText();
        }
    }
}
