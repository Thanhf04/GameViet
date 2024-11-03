using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class chuyenCanh : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    private void OnTriggerEnter2D(Collider2D collider){
    if(collider.CompareTag("Player")){
        playableDirector.Play();
        GetComponent<BoxCollider2D>().enabled = false;
    }
   }
}
