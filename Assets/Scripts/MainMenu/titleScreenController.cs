using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class titleScreenController : MonoBehaviour
{
    [SerializeField] public Image start;

    private void Start()
    {
        StartCoroutine(Blink());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(Blink());
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator Blink() 
    {
        while (true)
        {
            start.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            start.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
