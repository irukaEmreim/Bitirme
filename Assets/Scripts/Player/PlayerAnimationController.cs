using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    public GameManager gameManager;
    private Rigidbody rb;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update() {
        if (playerController.canMove)
        {
            animator.SetFloat("Speed",rb.velocity.magnitude);
            if (gameManager.gameOver)
            {
                animator.SetTrigger("Defeated");
            }
        }
        else
        {
            animator.SetFloat("Speed",0);
        }
    }





}
