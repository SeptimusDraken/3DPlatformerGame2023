using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Rigidbody rb;
    private MeshCollider coll;
    private Animator anim;

    bool canJump;

    private float dirX = 0f;
    private float dirZ = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, runningbackwards, jumping, jump }

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<MeshCollider>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirZ = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(dirX * moveSpeed, rb.velocity.y, dirZ * moveSpeed);


        if (Input.GetButtonDown("Jump") && canJump)
        {
            jumpSoundEffect.Play();
            canJump = false;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }


        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirZ > 0f)
        {
            state = MovementState.running;
        }
        else if (dirZ < 0f)
        {
            state = MovementState.runningbackwards;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y >= .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y >= .1f && dirX == 0f)
        {
            state = MovementState.jump;
        }

        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint x in collision.contacts)
        {
            if (x.point.y < transform.position.y - 0.1f)
            {
                //landSoundEffect.Play();
                canJump = true;
            }
        }
    }
}
