using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))] //Adds a character controller component to object

public class FirstPersonController : MonoBehaviour
{
    public Camera playerCamera;
    public Camera thirdPersonCamera;
    public float walkingSpeed = 4f;
    public float sprintingSpeed = 12f;
    public float jumpingPower = 2f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    Vector3 movementDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;
    public Animator anim;
    public AudioSource source;
    public AudioClip healClip;
    public AudioClip damageClip;

    public GameObject thirdPersonModel;
    bool thirdPersonActive;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject playerUI;

    CharacterController characterController;
    WeaponController weaponController;
    //[SerializeField] private GameObject weaponControllerObj;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera.enabled = true;
        thirdPersonCamera.enabled = false;
        anim = GetComponent<Animator>();
        thirdPersonActive = false;
        anim.enabled = false;

        currentHealth = maxHealth;
        deathScreen.SetActive(false);
        Time.timeScale = 1;
        playerUI.SetActive(true);
        //weaponController = GetComponent<WeaponController>();
        //weaponControllerObj = weaponController;
        GameObject weapon = GameObject.FindWithTag("Weapon Holder");
        weaponController = weapon.GetComponent<WeaponController>();
    }

    private void Update()
    {
        //Basic movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Sprinting
        //bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        bool isSprinting = false;
        float curSpeedX = canMove ? (isSprinting ? sprintingSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isSprinting ? sprintingSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = movementDirection.y;
        movementDirection = (forward * curSpeedX) + (right * curSpeedY);

        //Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            movementDirection.y = jumpingPower;
        }
        else
        {
            movementDirection.y = movementDirectionY;
        }
        if(!characterController.isGrounded)
        {
            movementDirection.y -= gravity * Time.deltaTime;
        }

        //Rotation
        characterController.Move(movementDirection * Time.deltaTime);
        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        //Camera switching
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (playerCamera.enabled == true)
            {
                playerCamera.enabled = false;
                thirdPersonCamera.enabled = true;
                thirdPersonModel.SetActive(true);
                thirdPersonActive = true;
                anim.enabled = true;
            }
            else if (thirdPersonCamera.enabled == true)
            {
                thirdPersonCamera.enabled = false;
                playerCamera.enabled = true;
                thirdPersonModel.SetActive(false);
                thirdPersonActive = false;
                anim.enabled = false;
            }
        }

        //TPS animations
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetFloat("speed", forward.magnitude);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetFloat("speed", right.magnitude);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetFloat("speed", forward.magnitude);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetFloat("speed", right.magnitude);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetFloat("speed", 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("speed", 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetFloat("speed", 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("speed", 0);
        }

        HealthUI.healthValue = currentHealth; //update current health in UI
    }

    public void PlayerTakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            playerUI.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Player is dead");
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //When player is colliding with enemy, health is quickly drained from them
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            PlayerTakeDamage(1);
            source.PlayOneShot(damageClip);

        }
        if (other.tag == "Projectile")
        {
            PlayerTakeDamage(20);
            source.PlayOneShot(damageClip);
        }

        if (other.tag == "Utility")
        {
            if (currentHealth < 100)
            {
                PlayerTakeDamage(-1);
                source.PlayOneShot(healClip);
            }
        }
        if (other.tag == "AmmoBox")
        {
            weaponController.currentArrows++;
            AmmoUI.ammo++;
            source.PlayOneShot(healClip);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AmmoBox")
        {
            weaponController.currentArrows++;
            AmmoUI.ammo++;
            source.PlayOneShot(healClip);

        }
    }


}
