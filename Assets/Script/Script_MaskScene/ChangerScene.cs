using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerScene : MonoBehaviour
{
    public GameObject PanelNPC;
    private void OnMouseDown()
    {
        OpenChatNPC();
    }
    public void GoToMiniGame2()
    {
        SceneManager.LoadScene("ManDuaBo");
    }
    public void OpenChatNPC()
    {
        PanelNPC.SetActive(true);
    }
    public void CloseChatNPC()
    {
        PanelNPC.SetActive(false);
    }

}
