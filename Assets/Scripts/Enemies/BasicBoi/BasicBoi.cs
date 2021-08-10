using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class BasicBoi : MonoBehaviour
{
    public float hp = 20;
    public float closeToPlayerOffset;
    public float bulletForce = 4f;
    public float followingRange = 25f;
    public float inaccuracy = 0.2f;

    public float shootCooldown = 1.5f;
    float shootTime = 0;

    bool seenPlayer = false;
    bool isDead = false;
    bool canAttack = false;

    DisableRagdoll ragdollCont;
    FieldOfView fov;

    NavMeshAgent agent;
    Rigidbody rb;
    CapsuleCollider agentColl;
    
    public AudioSource gunShotAudio;
    public AudioSource hitAudio;
    public Animator anim;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject projectile;
    public GameObject pistol;
    public Transform body;

    // Start is called before the first frame update
    void Start()
    {
        pistol.GetComponent<XRGrabInteractable>().enabled = false;
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        agentColl = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        ragdollCont = GetComponent<DisableRagdoll>();
        ragdollCont.TurnRagdoll(false);
    }

    void Update(){
        if(!seenPlayer){
            seenPlayer = fov.canSeePlayer;
        }

        if(seenPlayer && !isDead){
            Move();
        }

        if(player == null){
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if(shootTime > 0){
            shootTime -= Time.deltaTime;
            canAttack = false;
        } else {
            canAttack = true;
        }

        if(fov.canSeePlayer && !isDead){
            ShootPlayer();
        }
    }

    void ShootPlayer(){
        transform.LookAt(playerCamera.transform);

        if(canAttack){
            pistol.GetComponentInChildren<MuzzleFlash>().OnGunShot();
            gunShotAudio.Play();
            Rigidbody rb = Instantiate(projectile, pistol.GetComponentInChildren<ParticleSystem>().transform.position + transform.forward, transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce((transform.forward + (Random.insideUnitSphere * inaccuracy)) * 15f, ForceMode.Impulse);
            shootTime = shootCooldown * Random.Range(0.75f, 1.25f);
        }
    }

    void Move(){
        float destFromPlayer = Vector3.Distance(fov.player.transform.position, transform.position);

        if(destFromPlayer > followingRange){
            seenPlayer = false;
            anim.Play("Idle");
        }

        if((destFromPlayer > closeToPlayerOffset && !isDead) || (!fov.canSeePlayer && !isDead)){
            agent.SetDestination(player.transform.position);
            anim.Play("Walk");
            shootTime = shootCooldown * Random.Range(0.75f, 1.25f);
        }
        else
        {
            agent.SetDestination(transform.position);
            anim.Play("Shoot");
        }


    }

    public void Hit(float damage){
        hp -= damage;

        if(!isDead)
            hitAudio.Play();

        if(hp <= 0){
            if(!pistol.GetComponent<XRGrabInteractable>().enabled){
                pistol.GetComponent<XRGrabInteractable>().enabled = true;
                pistol.GetComponent<Rigidbody>().isKinematic = false;
                pistol.transform.parent = null;
            }

            agentColl.enabled = false;
            Vector3 bulletDir = (body.position - player.transform.position).normalized;
            isDead = true;
            anim.enabled = false;
            ragdollCont.TurnRagdoll(true);
            foreach(Rigidbody rba in ragdollCont.rbs){
                if(!isDead)
                    rba.velocity += bulletDir + Vector3.up * bulletForce;
                else 
                    rba.velocity += bulletDir * bulletForce * 0.5f;
            }
        }
    }
}
