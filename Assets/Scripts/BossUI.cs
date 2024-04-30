using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public static int healthValue = 0;
    Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {

        healthText.text = "" + healthValue;
    }
}
