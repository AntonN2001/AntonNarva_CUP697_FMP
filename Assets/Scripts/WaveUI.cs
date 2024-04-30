using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public static int waveNum = 0;
    Text waveText;

    void Start()
    {
        waveText = GetComponent<Text>();
    }

    void Update()
    {

        waveText.text = "WAVE: " + waveNum;
    }
}
