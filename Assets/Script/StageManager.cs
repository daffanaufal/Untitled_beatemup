using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Button buttonStage2;
    public Button buttonStage3;
<<<<<<< Updated upstream
=======

    // Gunakan flag untuk menandai apakah stage sudah di-set sebagai terbuka
    private bool stage2Unlocked = false;
    private bool stageBossUnlocked = false;
>>>>>>> Stashed changes

    void Start()
    {
        ResetStage();
        CheckStage();
    }

    public void CheckStage()
<<<<<<< Updated upstream
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
=======
    {
        // Periksa apakah stage sudah terbuka sebelumnya
        if (!stage2Unlocked)
        {
            int statusStage2 = PlayerPrefs.GetInt("Stage2");
            if (statusStage2 == 1)
            {
                buttonStage2.interactable = true;
                stage2Unlocked = true; // Tandai bahwa stage sudah terbuka
            }
            else
            {
                buttonStage2.interactable = false;
            }
        }

        // Periksa apakah stage Boss sudah terbuka sebelumnya
        if (!stageBossUnlocked)
        {
            int statusStageBoss = PlayerPrefs.GetInt("StageBoss");
            if (statusStageBoss == 1)
            {
                buttonStage3.interactable = true;
                stageBossUnlocked = true; // Tandai bahwa stage Boss sudah terbuka
            }
            else
            {
                buttonStage3.interactable = false;
            }
        }
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }


    //Stage2
    //StageBoss
>>>>>>> Stashed changes
    //1 == Unlock
    //0 == Lock
}