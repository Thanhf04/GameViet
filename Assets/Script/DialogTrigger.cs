using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
  public class DialogueCharacter{
    public string name;
    public Sprite icon;
  }

  [System.Serializable]
  public class DialogueLine{
    public DialogueCharacter character;
    [TextArea(3,10)]
    public string line;
  }

    [System.Serializable]
    public class Dialogue{
        public List<DialogueLine> dialogueLines = new List<DialogueLine>();
    }

public class DialogTrigger : MonoBehaviour
{
  public Dialogue dialogue;
  public void TriggerDialogue(){
    if (DialogManager.Instance == null) {
        Debug.LogError("DialogManager.Instance is null!");
        return;
    }
    
    if (dialogue == null) {
        Debug.LogError("Dialogue object is null! Make sure it is assigned in the Inspector.");
        return;
    }
    
    DialogManager.Instance.StartDialogue(dialogue);
}


  private void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player")){
        TriggerDialogue();
    }
  }
}
