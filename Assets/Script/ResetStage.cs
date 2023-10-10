using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStage : MonoBehaviour
{
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll(); // Ini akan menghapus semua data dalam PlayerPrefs
        PlayerPrefs.Save(); // Simpan perubahan
    }
}
