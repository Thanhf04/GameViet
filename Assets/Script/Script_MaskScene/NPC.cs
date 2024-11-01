using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Button BtnOpenShop;
    [SerializeField] private Button BtnCloseShop;

    private void OnMouseDown()
    {
        Panel.SetActive(true);
    }
    public void OpenShop()
    {
        Game.SetActive(true);
        Panel.SetActive(false);
    }
    public void CloseShop()
    {
        Panel.SetActive(false);
    }
}
