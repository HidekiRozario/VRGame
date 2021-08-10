using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    InputManager playerInput;

    public float border = -100f;
    public float groundDist = 0.1f;
    public float sprintSpeed = 6f;
    public float walkSpeed = 4f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity;
    public float maxHP = 50f;
    public float hp = 50f;
    public bool isGrounded;

    public Transform groundCheck;
    public Transform spawnPoint;
    public AudioSource playerHit;
    Rigidbody playerRB;
    
    public ContinuousMoveProviderBase playerLocomotion;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerInput = GameObject.Find("InputManager").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < border){
            Respawn();
        }
        

        Grounded();
        Jump();
        Sprint();
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
        transform.position = spawnPoint.position;
        hp = maxHP;
    }

    public void Hit(float damage){
        hp -= damage;
        playerHit.Play();

        if(hp <= 0){
            Respawn();
        }
    }
}
