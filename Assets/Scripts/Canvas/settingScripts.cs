using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingScripts : MonoBehaviour
{
    public GameObject settingUI, graphicMenu, volumeMenu, controlMenu, languageMenu;
    bool isOpenGraph, isOpenVol, isOpenControll, isOpenLang;

    // Start is called before the first frame update
    void Start()
    {
        languageMenu.SetActive(false);
        isOpenLang = false; 
        controlMenu.SetActive(false);
        isOpenControll = false;
    }

    public void closeSetting()
    {
        settingUI.SetActive(false);
    }

    public void openGraphicSetting()
    {
        if (isOpenVol || isOpenControll || isOpenLang)
        {
            volumeMenu.SetActive(false);
            isOpenVol = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
            languageMenu.SetActive(false);
            isOpenLang = false;
        }

        graphicMenu.SetActive(true);
        isOpenGraph = true;
    }

    public void openVolSetting()
    {
        if (isOpenGraph || isOpenControll || isOpenLang)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
            languageMenu.SetActive(false);
            isOpenLang = false;
        }

        volumeMenu.SetActive(true);
        isOpenVol = true;
    }

    public void openControllSetting()
    {
        if (isOpenVol || isOpenGraph || isOpenLang)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            volumeMenu.SetActive(false);
            isOpenVol = false;
            languageMenu.SetActive(false);
            isOpenLang = false;
        }

        controlMenu.SetActive(true);
        isOpenControll = true;
    }

    public void openLanguageSetting()
    {
        if (isOpenVol || isOpenGraph || isOpenControll)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            volumeMenu.SetActive(false);
            isOpenVol = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
        }

        languageMenu.SetActive(true);
        isOpenLang = true;
    }
}
