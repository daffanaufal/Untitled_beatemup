using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneCharater : MonoBehaviour
{
    public void PindahScene (string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

}