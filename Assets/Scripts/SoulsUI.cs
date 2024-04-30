using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsUI : MonoBehaviour
{
    public static int soulValue = 0;
    Text soulText;

    void Start()
    {
        soulText = GetComponent<Text>();
    }

    void Update()
    {

        soulText.text = "Souls: " + soulValue;
    }


}
