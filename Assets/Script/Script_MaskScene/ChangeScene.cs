using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject PanelChatNPC;
    private void OnMouseDown()
    {
        PanelChatNPC.SetActive(true);
    }
    public void OpenChatNPC()
    {
        GoToMiniGame2();
    }
    public void CloseChatNPC()
    {
        PanelChatNPC.SetActive(false);
    }
    public void GoToMiniGame2()
    {
        SceneManager.LoadScene("ManDuaBo");
    }
}
