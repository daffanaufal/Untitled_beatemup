using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptScene : MonoBehaviour
{
    public TextMeshProUGUI FinalScore, FinalTime;
    public GameObject WinUI;
    public GameObject[] locks; 
    public bool isFinished;

    private void Start()
    {
        WinUI.SetActive(false);
        isFinished = false;

        
        CheckAndSetLocks();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isFinished)
        {
            Continue("Stage2");
            Continue("Stage3");
            Continue("Stage4");
            Continue("Stage5");
        }

        ShowScore();
        ShowTime();
        Finish();
    }

    public void PindahScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void ShowScore()
    {
        FinalScore.text = ScoreController.singleton.GetTotalPoint().ToString();
    }

    public void ShowTime()
    {
        float TimeNow = TimeController.instance.TimeStage;
        float minute = Mathf.FloorToInt(TimeNow / 60);
        float second = Mathf.FloorToInt(TimeNow % 60);

        FinalTime.text = string.Format("{0,00}:{1,00}", minute, second);

        if (minute == 0)
        {
            FinalTime.text = second + " Detik";
        }
    }

    public void Finish()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Time.timeScale = 0;
            WinUI.SetActive(true);
            isFinished = true;
        }
    }

    public void Continue(string key)
    {
        // Next Stage Unlocked
        PlayerPrefs.SetInt(key, 1);
        SceneManager.LoadScene("StageSelection");

       
        CheckAndSetLocks();
    }

    // Metode untuk memeriksa dan mengatur status gembok
    void CheckAndSetLocks()
    {
        for (int i = 0; i < locks.Length; i++)
        {
            string stageKey = "Stage" + (i + 2); 

            // Jika PlayerPrefs menyatakan bahwa stage telah terbuka, gembok dihilangkan
            if (PlayerPrefs.GetInt(stageKey, 0) == 1)
            {
                locks[i].SetActive(false); 
            }
            
        }
    }
}
