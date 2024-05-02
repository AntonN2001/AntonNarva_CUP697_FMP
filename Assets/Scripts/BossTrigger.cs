using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject bossActivate;
    [SerializeField] private GameObject bossUI;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject gameManager2;
    public AudioSource source;
    public AudioClip clip;
    public bool audioPlayed;

    void Start()
    {
        barrier.SetActive(false);
        bossActivate.SetActive(false);
        bossUI.SetActive(false);
        gameManager.SetActive(false);
        gameManager2.SetActive(false);
        audioPlayed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (audioPlayed == false))
        {
            barrier.SetActive(true);
            bossActivate.SetActive(true);
            bossUI.SetActive(true);
            gameManager.SetActive(true);
            gameManager2.SetActive(true);
            source.loop = true;
            source.PlayOneShot(clip);
            audioPlayed = true;
        }
    }
}
