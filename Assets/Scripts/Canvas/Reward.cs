using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField]
    public GameObject RewardCanvas;
    private Player_Health playerHealth;


    public void increaseshp()
    {
        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }


    public void increasesspeed()
    {

    }
    public void increasestime()
    {

    }
    public void increasesspecialDMG()
    {

    }
    public void increasesDMG()
    {

    }
    public void Skipreward()
    {
        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
