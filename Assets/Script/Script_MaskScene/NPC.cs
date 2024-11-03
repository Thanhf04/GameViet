using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject PanelGame;
    [SerializeField] private GameObject PanelSuccess;
    [SerializeField] private Button BtnOpenShop;
    [SerializeField] private Button BtnCloseShop;

    private void OnMouseDown()
    {
        if (!Game.activeSelf)
        {
            PanelGame.SetActive(true);
        }
    }
    public void OpenShop()
    {
        Game.SetActive(true);
        PanelGame.SetActive(false);
    }
    public void CloseShop()
    {
        Game.SetActive(false);
        PanelSuccess.SetActive(false);
    }
    public void ClosePanel()
    {
        PanelGame.SetActive(false);
    }
    public void ClickButtonSuccess()
    {
        PanelSuccess.SetActive(true);
    }
}
