using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Button buttonStage2;
    public Button buttonStage3;

    void Start()
    {
        ResetStage();
        CheckStage();
    }

    public void CheckStage()
    {
        int statusStage2 = PlayerPrefs.GetInt("Stage2");     //int statusStage2 = PlayerPrefs.GetInt("Stage2", 0);
        int statusStageBoss = PlayerPrefs.GetInt("StageBoss");     //int statusStage3 = PlayerPrefs.GetInt("StageBoss", 0);

        if (statusStage2 == 1)
            buttonStage2.interactable = true;
        else
            buttonStage2.interactable = false;

        if (statusStageBoss == 1)
            buttonStage3.interactable = true;
        else
            buttonStage3.interactable = false;
    }

    public void ResetStage()
    {
        PlayerPrefs.DeleteKey("Stage2");
        PlayerPrefs.DeleteKey("StageBoss");
        PlayerPrefs.Save();
    }

    //public void ResetPlayerPrefs()
    //{
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save(); 
    //}


    //Stage2 
    //Stage3
    //1 == Unlock
    //0 == Lock
}