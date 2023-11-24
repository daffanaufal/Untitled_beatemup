using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;


    float totalScore;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        totalScore = 0;
        scoreText.text = totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = totalScore.ToString();
    }

    public void GetPoint(float point)
    {
        totalScore += point;
    }
}
