using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    
    [SerializeField] private GameObject Panel;
    [SerializeField] private Button BtnTiepTuc;
    // [SerializeField] private Button BtnHuy;

    private void OnMouseDown()
    {
        Panel.SetActive(true);
    }
    public void OpenShop()
    {
        Panel.SetActive(false);
    }
    public void CloseShop()
    {
        Panel.SetActive(false);
    }
}
