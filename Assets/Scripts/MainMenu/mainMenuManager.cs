using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public void Enter(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void Setting()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
