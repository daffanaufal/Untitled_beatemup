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
        if (WinUI != null) // Pastikan WinUI sudah diinisialisasi sebelum digunakan
        {
            WinUI.SetActive(false);
        }
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

        // Periksa apakah FinalScore dan FinalTime sudah diinisialisasi sebelum dipakai
        if (FinalScore != null && FinalTime != null)
        {
            ShowScore();
            ShowTime();
        }

        Finish();
    }

    public void PindahScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void ShowScore()
    {
        if (ScoreController.singleton != null) // Periksa jika singleton sudah terinisialisasi
        {
            FinalScore.text = ScoreController.singleton.GetTotalPoint().ToString();
        }
    }

    public void ShowTime()
    {
        if (TimeController.instance != null) // Periksa jika instance sudah terinisialisasi
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
    }

    public void Finish()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Time.timeScale = 0;
            if (WinUI != null) // Periksa jika WinUI sudah diinisialisasi sebelum digunakan
            {
                WinUI.SetActive(true);
            }
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
        if (locks != null) // Periksa jika locks sudah diinisialisasi sebelum digunakan
        {
            for (int i = 0; i < locks.Length; i++)
            {
                string stageKey = "Stage" + (i + 2);

                // Jika PlayerPrefs menyatakan bahwa stage telah terbuka, gembok dihilangkan
                if (PlayerPrefs.GetInt(stageKey, 0) == 1)
                {
                    if (locks[i] != null) 
                    {
                        locks[i].SetActive(false);
                    }
                }
            }
        }
    }
}
