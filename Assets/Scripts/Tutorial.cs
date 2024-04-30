using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText1;
    [SerializeField] private GameObject tutorialText2;
    [SerializeField] private GameObject tutorialText3;
    [SerializeField] private GameObject tutorialText4;
    [SerializeField] private GameObject spawnEnemy;
    private int tutorialPhase;

    void Start()
    {
        tutorialText1.SetActive(true);
        tutorialText2.SetActive(false);
        tutorialText3.SetActive(false);
        tutorialText4.SetActive(false);
        tutorialPhase = 0;
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if(tutorialPhase == 0)
            {
                tutorialText1.SetActive(false);
                tutorialText2.SetActive(true);
                tutorialPhase = 1;
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(tutorialPhase == 1)
            {
                tutorialText2.SetActive(false);
                tutorialText3.SetActive(true);
                tutorialPhase = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
                if (tutorialPhase == 2)
                {
                    tutorialText3.SetActive(false);
                    tutorialText4.SetActive(true);
                    tutorialPhase = 3;
                }
        }

        if(tutorialPhase == 3)
        {
            spawnEnemy.SetActive(true);
        }
    }
}
