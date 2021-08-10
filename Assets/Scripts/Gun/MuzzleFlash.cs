using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    AudioSource gunAudioSource;
    public ParticleSystem muzzleflash;

    void Start(){
        gunAudioSource = GetComponent<AudioSource>();
    }

    public void OnGunShot(){
        muzzleflash.Play();
        gunAudioSource.Play();
    }
}
