using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject bossActivate;
    [SerializeField] private GameObject bossUI;
    [SerializeField] private GameObject gameManager;
    public AudioSource source;
    public AudioClip clip;
    private bool audioPlayed;

    void Start()
    {
        barrier.SetActive(false);
        bossActivate.SetActive(false);
        bossUI.SetActive(false);
        gameManager.SetActive(false);
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
            source.loop = true;
            source.PlayOneShot(clip);
            audioPlayed = true;
        }
    }
}
