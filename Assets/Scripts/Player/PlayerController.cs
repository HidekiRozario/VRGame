using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    public InputManager playerInput;
    public ContinuousMoveProviderBase playerLocomotion;

    public float border = -100f;
    public float groundDist = 0.1f;
    public float sprintSpeed = 6f;
    public float walkSpeed = 4f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity;
    public float maxHP = 50f;
    public bool spawnProtect = true;

    float hp = 50f;

    bool isGrounded;
    bool isPaused = false;
    bool isClicked = false;
    bool isSlowed = false;
    bool isClickedSlowed = false;

    float spawnCooldown = 1f;
    float spawnProcTime = 1f;

    public GameObject UIMenu;
    public Transform groundCheck;
    public Transform spawnPoint;
    public AudioSource playerHit;

    Rigidbody playerRB;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        Jump();
        Sprint();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnProcTime > 0){
            spawnProcTime -= Time.deltaTime;
            spawnProtect = true;
        } else spawnProtect = false;

        if(gameObject.transform.position.y < border){
            Respawn();
        }
        
        if(playerInput.secondaryButtonLeft){
            if(isClicked){
                isClicked = false;
                Menu();
            }
        } else if(!isClicked && !playerInput.secondaryButtonLeft){
            isClicked = true;
        }

        if(playerInput.secondaryButtonRight){
            if(isClickedSlowed){
                isClickedSlowed = false;
                SlowMotion();
            }
        } else if(!isClickedSlowed && !playerInput.secondaryButtonRight){
            isClickedSlowed = true;
        }
        
        Grounded();
    }

    void Menu(){
        if(!isPaused){
            isPaused = true;
            UIMenu.SetActive(true);
        }
        else{
            isPaused = false;
            UIMenu.SetActive(false);
        }
    }

    void SlowMotion(){
        if(!isSlowed){
            isSlowed = true;
            Time.timeScale = 0.25f;
            Time.fixedDeltaTime = .01f * Time.timeScale;
        }
        else{
            isSlowed = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = .01f * Time.timeScale;
        }
    }

    void Grounded(){
        RaycastHit hit;

        if(Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDist)){
            isGrounded = true;
        } else{
            isGrounded = false;
        }
    }

    void Jump(){
        if(playerInput.joystickClickRight && isGrounded){
            playerRB.velocity = Vector3.up * jumpVelocity;
        }
        if(playerRB.velocity.y < 0){
            playerRB.velocity += Vector3.up * Physics.gravity.y/2 * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void Sprint(){
        if(playerInput.joystickClickLeft){
            playerLocomotion.moveSpeed = sprintSpeed;
        }
        else{
            playerLocomotion.moveSpeed = walkSpeed;
        }

    }

    void Respawn(){
        spawnProcTime = spawnCooldown;
        transform.position = spawnPoint.position;
        hp = maxHP;
    }

    public void Hit(float damage){
        if(spawnProcTime <= 0){
            hp -= damage;
            playerHit.Play();
        }

        if(hp <= 0){
            Respawn();
        }
    }
}
