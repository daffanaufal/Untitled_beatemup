using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goScripts : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("StageSelection");
        Time.timeScale = 1;
    }
}
