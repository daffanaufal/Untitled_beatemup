using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptScene : MonoBehaviour
{
    public KeyCode backButtonKey = KeyCode.Escape;
    public string backButtonName = "XboxBack"; // Nama tombol "View" pada Xbox controller

    void Update()
    {
        // Periksa apakah tombol keyboard yang ditentukan ditekan
        if (Input.GetKeyDown(backButtonKey))
        {
            GoBack();
        }

        // Periksa apakah tombol "View" pada Xbox controller ditekan
        if (Input.GetButton("XboxBack"))
        {
            GoBack();
        }
    }

    public void PindahScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void GoBack()
    {
        // Kembali ke scene sebelumnya
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}
