using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearUI : MonoBehaviour
{
    public static int spears = 0;
    Text spearText;

    void Start()
    {
        spearText = GetComponent<Text>();
    }

    void Update()
    {

        spearText.text = "" + spears;
    }
}
