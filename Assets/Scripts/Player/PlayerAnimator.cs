using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private int isJumpintHash;
    private int velocityHash;

    private float playerVelocity;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        isJumpintHash = Animator.StringToHash("isJumping");
        velocityHash = Animator.StringToHash("velocity");

    }

    private void AnimatorHandler()
    {
        bool isJumpingAnimation = animator.GetBool(isJumpintHash);
        animator.SetFloat(velocityHash, playerVelocity);
        animator.SetBool(isJumpintHash, isJumpingAnimation);
    }


    // Update is called once per frame
    void Update()
    {
        playerVelocity = PlayerManager.instance.GetCurrentVelocity();
    }
}
