using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptScene : MonoBehaviour
{
    public KeyCode backButtonKey = KeyCode.Escape;

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
}