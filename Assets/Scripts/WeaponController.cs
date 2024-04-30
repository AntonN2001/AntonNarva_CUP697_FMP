using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Crossbow;
    public GameObject CrossbowArrow;
    public GameObject Spear;
    bool crossbowActive, swordActive, spearActive;

    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public AudioClip SwordAttackSound;
    public AudioClip CrossbowAttackSound;
    public AudioClip SpearAttackSound;
    public bool isAttacking = false;
    public int weaponSelect;

    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;
    public float arrowSpeed = 10;
    public int currentArrows;
    public int maxArrows = 10;

    public Transform spearSpawnPoint;
    public GameObject spearPrefab;
    public float spearSpeed = 10;
    public int currentSpears;
    public int maxSpears = 5;

    void Start()
    {
        weaponSelect = 1;
        swordActive = true;
        spearActive = true;
        currentArrows = maxArrows;
        currentSpears = maxSpears;
        AmmoUI.ammo = currentArrows;
        SpearUI.spears = currentSpears;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Sword.SetActive(true);
            Crossbow.SetActive(false);
            swordActive = true;
            crossbowActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Crossbow.SetActive(true);
            Sword.SetActive(false);
            crossbowActive = true;
            swordActive = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(canAttack)
            {
                if(swordActive)
                {
                    SwordAttack();
                }
                else if(crossbowActive)
                {
                    if(currentArrows > 0)
                    {
                        CrossbowAttack();
                    }
                    else if (currentArrows == 0)
                    {
                        CrossbowArrow.SetActive(false);
                        Debug.Log("Out of arrows");
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(canAttack)
            {
                if (currentSpears > 0)
                {
                    SpearAttack();
                }
                else if (currentSpears == 0)
                {
                    //Spear.SetActive(false);
                    Debug.Log("Out of spears");
                }
            }
        }
    }


    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("SwordAttack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void CrossbowAttack()
    {
        currentArrows--;
        AmmoUI.ammo--;
        isAttacking = true;
        canAttack = false;
        var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.transform.rotation * Quaternion.Euler(-90,0,90));
        arrow.GetComponent<Rigidbody>().velocity = arrowSpawnPoint.forward * arrowSpeed;

        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(CrossbowAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SpearAttack()
    {
        Spear.SetActive(true);
        currentSpears--;
        SpearUI.spears--;
        isAttacking = true;
        canAttack = false;
        var spear = Instantiate(spearPrefab, spearSpawnPoint.position, spearSpawnPoint.transform.rotation * Quaternion.Euler(0, 0, 90));
        spear.GetComponent<Rigidbody>().velocity = spearSpawnPoint.forward * spearSpeed;

        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SpearAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        Spear.SetActive(false);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
