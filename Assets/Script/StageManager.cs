using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Button buttonStage2;
    public Button buttonStage3;

    // Gunakan flag untuk menandai apakah stage sudah di-set sebagai terbuka
    private bool stage2Unlocked = false;
    private bool stageBossUnlocked = false;

    void Start()
    {
        ResetStage();
        CheckStage();
    }

    public void CheckStage()
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

    public void ResetStage()
    {
        PlayerPrefs.DeleteKey("Stage2"); // Hapus data PlayerPrefs untuk Stage2
        PlayerPrefs.DeleteKey("StageBoss"); // Hapus data PlayerPrefs untuk StageBoss
    }




    //Stage2
    //StageBoss
    //1 == Unlock
    //0 == Lock
}