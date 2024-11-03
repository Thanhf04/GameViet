using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class chuyenMap : MonoBehaviour
{
    public float delaySecond = 2;
    public string nameScene = "ManDuaBo";
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            collider.gameObject.SetActive(false);

            modeSelect();
        }
    }

    public void modeSelect(){
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay(){
        yield return new WaitForSeconds(delaySecond);
         
        SceneManager.LoadScene(nameScene);
    }
}
