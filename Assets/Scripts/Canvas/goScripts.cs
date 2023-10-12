using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goScripts : MonoBehaviour
{
<<<<<<< Updated upstream
    GameObject gameOverUI;

    public void Start()
=======
    public GameObject gameOverUI;

    private void Start()
>>>>>>> Stashed changes
    {
        gameOverUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene("StageSelection");
    }
}
