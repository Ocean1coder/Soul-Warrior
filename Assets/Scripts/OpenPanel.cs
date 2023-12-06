using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
   public GameObject panelPause;

   public GameObject panelShop;

   public GameObject panelUpgrade;

   public GameObject panelQuest;

    public void OpenPanelPause()
    {
        if(panelPause != null)
        {
            bool isActive =  panelPause.activeSelf;
            panelPause.SetActive(!isActive);
        }
    }
    public void OpenPanelShop()
    {
        if(panelShop != null)
        {
            bool isActive =  panelShop.activeSelf;
            panelShop.SetActive(!isActive);
        }
    }
    public void OpenPanelUpgrade()
    {
        if(panelUpgrade != null)
        {
            bool isActive =  panelUpgrade.activeSelf;
            panelUpgrade.SetActive(!isActive);
        }
    }
    public void OpenPanelQuest()
    {
        if(panelQuest != null)
        {
            bool isActive =  panelQuest.activeSelf;
            panelQuest.SetActive(!isActive);
        }
    }
}
