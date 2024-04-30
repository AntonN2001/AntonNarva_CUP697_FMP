using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSystem : MonoBehaviour
{
    public int numberOfSouls { get; private set; }
    public AudioClip soulCollected;

    public void SoulCollected()
    {
        numberOfSouls++;
        SoulsUI.soulValue++;
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(soulCollected);
    }
}
