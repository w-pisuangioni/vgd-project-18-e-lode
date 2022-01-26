using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_audio : MonoBehaviour {

    private AudioSource footsound;
    private AudioSource attacksound;
    private AudioSource hitsound;
    private AudioSource dyingsound;
    private bool walking;
    private bool attack;
    private bool hit;
    private float die;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        AudioSource[] factory = gameObject.GetComponents<AudioSource>();
        footsound = factory[0]; // 0 is the index number,for another sound it will be 1
        attacksound = factory[1];
        hitsound = factory[2];
        dyingsound = factory[3];
        walking = animator.GetBool("Walk");
        attack = animator.GetBool("Attacking");
        hit = animator.GetBool("Hit");
        die = animator.GetFloat("Life");

        if (walking == true)//walking would be a variable ,that makes the script aware the the player walks
        {
            if (!footsound.isPlaying)
            {
                footsound.Play();
                footsound.loop = true;
            }
        }

        else
        {
            footsound.Stop();
        }
        //Suono dell'attacco
        if (attack == true)
        {
            if (!attacksound.isPlaying)
            {
                attacksound.Play();
                attacksound.loop = true;
            }
        }
        else
        {
            attacksound.Stop();
        }

        //Suono zombie viene colpito
        if (hit == true)
            if (!hitsound.isPlaying)
            {
                hitsound.Play();
                hitsound.loop = false;
            }
            else
            {
                hitsound.Stop();
            }

        if (die < 0.1)
        {
            if (!dyingsound.isPlaying)
            {
                dyingsound.Play();
                dyingsound.loop = true;
            }
        }
        else
        {
            dyingsound.Stop();
        }

    }
   
}
