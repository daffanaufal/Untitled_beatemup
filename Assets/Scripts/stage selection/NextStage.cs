using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public ScriptScene scriptScene;

    // Update is called once per frame
    void Update()
    {
        // Cek jika tombol "Tab" ditekan
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Panggil fungsi nextStage dengan kunci yang sesuai
            nextStage("Stage2");
            nextStage("StageBoss");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Tambahkan logika pembatalan tindakan di sini
            // Misalnya, kembali ke scene pemilihan stage
            scriptScene.PindahScene("StageSelection");
        }


    }

    public void nextStage(string key)
    {
        //Next Stage Unlocked
        PlayerPrefs.SetInt(key, 1); //PlayerPrefs.SetInt(key, 1);
        scriptScene.PindahScene("StageSelection");
    }
}
