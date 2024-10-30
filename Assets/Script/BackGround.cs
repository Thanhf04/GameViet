using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBg;
    public Transform SlideBG;
    public float Lenght;

    void Update()
    {
        if (mainCam.position.x>midBg.position.x)
        {
        UpdateBackgroundPosition(Vector3.right);
        }
        else if (mainCam.position.x<midBg.position.x)
        {
            UpdateBackgroundPosition(Vector3.left);
        }
        
    }
    void UpdateBackgroundPosition(Vector3 direction)
    {
        SlideBG.position = midBg.position + direction * Lenght;
        Transform temp = midBg;
        midBg = SlideBG;
        SlideBG = temp;

    }
}
