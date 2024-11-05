// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement; 

// public class chuyenMap : MonoBehaviour
// {
//     public float delaySecond = 2;
//     public string nameScene = "ManDuaBo";

//     void OnTriggerEnter2D(Collider2D collider){
//         if(collider.CompareTag("Player")){
//             collider.gameObject.SetActive(false);

//             modeSelect();
//         }
//     }

//     public void modeSelect(){
//         StartCoroutine(LoadAfterDelay());
//     }

//     IEnumerator LoadAfterDelay(){
//         yield return new WaitForSeconds(delaySecond);

//         SceneManager.LoadScene(nameScene);
//     }
// }
// {
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chuyenMap : MonoBehaviour
{
    public float delaySecond = 2f;
    public string nameScene = "ManDuaBo";

    // Vị trí mà Player sẽ được dịch chuyển đến khi quay lại Map1
    public Vector3 returnPositionInMap1; // Cài đặt vị trí này trong Inspector

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Lưu vị trí của Player trước khi chuyển đi
            PlayerDataManager.Instance.playerPosition = returnPositionInMap1; // Lưu vị trí đã định trước
            collider.gameObject.SetActive(false); // Ẩn Player trước khi chuyển scene

            modeSelect();
        }
    }

    public void modeSelect()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene(nameScene);
    }
}

