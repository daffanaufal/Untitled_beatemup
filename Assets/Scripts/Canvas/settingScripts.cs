using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingScripts : MonoBehaviour
{
    public GameObject settingUI, graphicMenu, AATMenu, controlMenu;
    bool isOpenGraph, isOpenAAT, isOpenControll;

    // Start is called before the first frame update
    void Start()
    {
        AATMenu.SetActive(false);
        isOpenAAT = false; 
        controlMenu.SetActive(false);
        isOpenControll = false;
    }

    public void closeSetting()
    {
        settingUI.SetActive(false);
    }

    public void openGraphicSetting()
    {
        if (isOpenAAT || isOpenControll)
        {
            AATMenu.SetActive(false);
            isOpenAAT = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
        }

        graphicMenu.SetActive(true);
        isOpenGraph = true;
    }

    public void openAATSetting()
    {
        if (isOpenGraph || isOpenControll)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
        }

        AATMenu.SetActive(true);
        isOpenAAT = true;
    }

    public void openControllSetting()
    {
        if (isOpenAAT || isOpenGraph)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            AATMenu.SetActive(false);
            isOpenAAT = false;
        }

        controlMenu.SetActive(true);
        isOpenControll = true;
    }

}
