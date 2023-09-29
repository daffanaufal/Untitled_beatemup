using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject previewStage1;
    public GameObject previewStage2;
    public GameObject previewStage3;

    private bool isButtonStage2Selected = true;

    // Tambahkan dua GameObject berikut untuk merepresentasikan tombol Stage 2 dan Stage 3
    public GameObject buttonStage2;
    public GameObject buttonStage3;

    void Start()
    {
        CheckStage();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isButtonStage2Selected = true;
            buttonStage2.GetComponent<Button>().Select(); // Memilih tombol tahap 2
            previewStage2.SetActive(true);
            previewStage1.SetActive(false);
            previewStage3.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isButtonStage2Selected = false;
            buttonStage3.GetComponent<Button>().Select(); // Memilih tombol tahap 3
            previewStage3.SetActive(true);
            previewStage1.SetActive(false);
            previewStage2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isButtonStage2Selected)
            {
                // Lakukan sesuatu saat tombol tahap 2 dipilih
            }
            else
            {
                // Lakukan sesuatu saat tombol tahap 3 dipilih
            }
        }
    }

    public void CheckStage()
    {
        int statusStage2 = PlayerPrefs.GetInt("Stage2");
        int statusStageBoss = PlayerPrefs.GetInt("StageBoss");

        if (statusStage2 == 1)
            buttonStage2.GetComponent<Button>().interactable = true;
        else
            buttonStage2.GetComponent<Button>().interactable = false;

        if (statusStageBoss == 1)
            buttonStage3.GetComponent<Button>().interactable = true;
        else
            buttonStage3.GetComponent<Button>().interactable = false;
    }
}
