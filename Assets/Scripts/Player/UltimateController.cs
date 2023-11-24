using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateController : MonoBehaviour
{
    public static UltimateController singleton;

    [SerializeField] Image[] fillUI;
    private int MaxLayer_1 = 20,
                MaxLayer_2 = 40,
                MaxLayer_3 = 60,
                MaxLayer_4 = 80,
                MaxLayer_5 = 100;

    private float ChargeSpeed = 1.5f, charge;
    bool isCharged;

    // Start is called before the first frame update
    void Awake()
    {
        singleton = this;
        charge = 0f;
        isCharged = false;

        for(int i = 0; i < 5; i++)
        {
            fillUI[i].fillAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fillUI[4].fillAmount <= 1)
        {
            charge += ChargeSpeed * Time.deltaTime;
            fillUI[4].fillAmount = charge / MaxLayer_5;
            fillUI[3].fillAmount = charge / MaxLayer_4;
            fillUI[2].fillAmount = charge / MaxLayer_3;
            fillUI[1].fillAmount = charge / MaxLayer_2;
            fillUI[0].fillAmount = charge / MaxLayer_1;
        }
        
        if(fillUI[4].fillAmount == 1)
        {
            isCharged = true;
            Debug.Log("Ultimate Charged");
        }
    }

    public bool UltimateCharged()
    {
        return isCharged;
    }
}
