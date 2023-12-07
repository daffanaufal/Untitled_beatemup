using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    private bool isFirst = false;

    [SerializeField]
    private GameObject VideoPlayerMove;

    [SerializeField]
    private GameObject VideoPlayerCom;

    [SerializeField]
    private GameObject TutorialCanvas;

    [SerializeField]
    private GameObject[] TutorialPage;

    [SerializeField]
    private GameObject[] SubMovement;

    [SerializeField]
    private GameObject[] SubCombat;

    [SerializeField]
    private GameObject[] PageDot;

    private int current, previous, subCurrMove, subPrevMove, subCurrCom, subPrevCom;


    private void Awake()
    {
        Time.timeScale = 0;
        current = 0;
        previous = 0;
        subCurrMove = 0;
        subPrevMove = 0;
        subCurrCom = 0;
        subPrevCom = 0;

        VideoPlayerMove.SetActive(false);
        VideoPlayerCom.SetActive(false);


        if (isFirst)
        {
            TutorialCanvas.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        TutorialPage[current].SetActive(true);
        PageDot[current].SetActive(true);
    }

    public void PreviousPage()
    {
        TutorialPage[current].SetActive(false);
        PageDot[current].SetActive(false);
        
        if(current >= 0)
        {
            previous--;

            if(previous == -1)
            {
                previous = TutorialPage.Length - 1;
            }

        }

        current = previous;

        if (current == 1)
        {
            VideoPlayerMove.SetActive(true);
            VideoPlayerCom.SetActive(false);

        }
        else if(current == 2)
        {
            VideoPlayerMove.SetActive(false);
            VideoPlayerCom.SetActive(true);
        }
        else
        {
            VideoPlayerMove.SetActive(false);
            VideoPlayerCom.SetActive(false);
        }

        TutorialPage[current].SetActive(true);
        PageDot[current].SetActive(true);
    }

    public void NextPage()
    {
        TutorialPage[current].SetActive(false);
        PageDot[current].SetActive(false);
        previous = current;

        if(current <= TutorialPage.Length)
        {
            current++;

            if(current == TutorialPage.Length)
            {
                current = 0;
            }
        }

        if (current == 1)
        {
            VideoPlayerMove.SetActive(true);
            VideoPlayerCom.SetActive(false);

        }
        else if (current == 2)
        {
            VideoPlayerMove.SetActive(false);
            VideoPlayerCom.SetActive(true);
        }
        else
        {
            VideoPlayerMove.SetActive(false);
            VideoPlayerCom.SetActive(false);
        }

        TutorialPage[current].SetActive(true);
        PageDot[current].SetActive(true);
    }

    public void NextSubMove()
    {

        SubMovement[subCurrMove].SetActive(false);
        subPrevMove = subCurrMove;

        if(subCurrMove <= SubMovement.Length)
        {
            subCurrMove++;

            if(subCurrMove == SubMovement.Length)
            {
                subCurrMove = 0;
            }
        }
        VideoController.instance.PlayVideo(subCurrMove);
        SubMovement[subCurrMove].SetActive(true);
    }

    public void PrevSubMove()
    {
        SubMovement[subCurrMove].SetActive(false);
        

        if (subCurrMove >= 0)
        {
            subPrevMove--;

            if (subPrevMove == -1)
            {
                subPrevMove = SubMovement.Length - 1;
            }
        }

        subCurrMove = subPrevMove;
        VideoController.instance.PlayVideo(subCurrMove);
        SubMovement[subCurrMove].SetActive(true);
    }

    public void NextSubCombat()
    {
        SubCombat[subCurrCom].SetActive(false);
        subPrevCom = subCurrCom;

        if (subCurrCom <= SubCombat.Length)
        {
            subCurrCom++;

            if (subCurrCom == SubCombat.Length)
            {
                subCurrCom = 0;
            }
        }
        VideoController.instance.PlayVideo(subCurrCom);
        SubCombat[subCurrCom].SetActive(true);
    }

    public void PrevSubCombat()
    {
        SubCombat[subCurrCom].SetActive(false);


        if (subCurrCom >= 0)
        {
            subPrevCom--;

            if (subPrevCom == -1)
            {
                subPrevCom = SubCombat.Length - 1;
            }
        }

        subCurrCom = subPrevCom;
        VideoController.instance.PlayVideo(subCurrCom);
        SubCombat[subCurrCom].SetActive(true);
    }

    public void closeTutorial()
    {
        TutorialCanvas.SetActive(false);
        isFirst = !isFirst;
        Time.timeScale = 1;
    }

}
