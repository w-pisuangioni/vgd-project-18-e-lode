using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Enemies{

    //the speed you want your player to move with.
    public float speed;

    public float distanceToGround;
    private RaycastHit hit = new RaycastHit();

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        startHealth = 250f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damage = 30;
        health = startHealth;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        WalkForward();
        Attack();
        drop = GetComponentInParent<Pickup>().getSpawnedItem();
        HitConstraints();
        DistFromGround();
        DragOntheGround();


    }

    void WalkForward()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            animator.SetBool("Walk", true);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            animator.SetBool("Walk", false);
    }
    private void DistFromGround()
    {
        
        if (Physics.Raycast(this.transform.position, -Vector3.up, out hit))
        {
            distanceToGround = hit.distance;
        }
    }

    private void DragOntheGround()
    {
        if (distanceToGround <= 1)
            this.GetComponent<Rigidbody>().drag = 100;
        else
            this.GetComponent<Rigidbody>().drag = 0;
    }
}
