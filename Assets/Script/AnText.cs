using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnText : MonoBehaviour
{
    public GameObject textObject1;
    public GameObject textObject2;
    public GameObject textObject3;
    public GameObject textObject4;
    public PlayableDirector playableDirector;
    void Start()
    {
        textObject1.SetActive(false); // Bắt đầu ẩn văn bản
        textObject2.SetActive(false);
        textObject3.SetActive(false);
        textObject4.SetActive(false);

        playableDirector.played += OnPlayableDirectorPlayed; // Đăng ký sự kiện
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

       private void OnPlayableDirectorPlayed(PlayableDirector director)
    {
        // Hiển thị văn bản khi Timeline bắt đầu
        textObject1.SetActive(true);
        textObject2.SetActive(true);
        textObject3.SetActive(true);
        textObject4.SetActive(true);
    }

    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        // Ẩn văn bản khi Timeline dừng lại
        textObject1.SetActive(false);
        textObject2.SetActive(false);
        textObject3.SetActive(false);
        textObject4.SetActive(false);
    }

}
