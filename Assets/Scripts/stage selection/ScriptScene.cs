using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptScene : MonoBehaviour
{
    public KeyCode backButtonKey = KeyCode.Space;
    public TextMeshProUGUI FinalScore, FinalTime;
    public GameObject WinUI;

    private void Start()
    {
        WinUI.SetActive(false);
        
    }

    void Update()
    {
        // Periksa apakah tombol keyboard yang ditentukan ditekan
        if (Input.GetKeyDown(backButtonKey))
        {
            // Kembali ke scene sebelumnya
            int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
            if (previousSceneIndex >= 0)
            {
                SceneManager.LoadScene(previousSceneIndex);
            }
        }
        ShowScore();
        ShowTime();
        Finish();
    }

    public void PindahScene (string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void GoBack()
    {
        // Kembali ke scene sebelumnya
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ShowScore()
    {
        FinalScore.text = ScoreController.singleton.GetTotalPoint().ToString();
    }

    public void ShowTime()
    {
        TimeController.instance.TimeStage -= Time.deltaTime;
        float minute = Mathf.FloorToInt(TimeController.instance.TimeStage / 60);
        float second = Mathf.FloorToInt(TimeController.instance.TimeStage % 60);

        FinalTime.text = string.Format("{0,00}:{1,00}", minute, second);
    }

    public void Finish()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Time.timeScale = 0;
            WinUI.SetActive(true);
        }
    }
}