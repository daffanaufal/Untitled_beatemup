using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public ScriptScene scriptScene;

    public void nextStage (string key)
    {
        //Next Stage Unlocked
        PlayerPrefs.SetInt(key, 1); //PlayerPrefs.SetInt(key, 1);
        scriptScene.PindahScene("StageSelection");
    }

}
