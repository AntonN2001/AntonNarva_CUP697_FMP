using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public static int ammo = 0;
    Text ammoText;

    void Start()
    {
        ammoText = GetComponent<Text>();
    }

    void Update()
    {

        ammoText.text = "" + ammo;
    }
}
