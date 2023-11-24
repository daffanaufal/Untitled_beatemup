using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage_time : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        timer *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int second = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, second);

        if(timer == 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
