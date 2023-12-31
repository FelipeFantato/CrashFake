using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private const float GravityScale = -9.81F;
    private CharacterController characterController;
    private Animator animator;
    private Vector3 cameraRelativeMovement;

    private float currentVelocity;

    private int isWalkingHash;
    private int isJumpingHash;
    private int velocityHash;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        GetAnimatorParameters();
    }

    void FixedUpdate()
    {
        AnimationHandler();
        RotationHandler();
    }

    private void AnimationHandler()
    {

        bool isJumpingAnimation = animator.GetBool(isJumpingHash);
        animator.SetFloat(velocityHash, currentVelocity);
    }

    private Vector3 ConverToCameraSpace(Vector3 vectorToRotate)
    {
        float currentYValue = vectorToRotate.y;

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 cameraForwardZproduct = vectorToRotate.z * cameraForward;
        Vector3 cameraRightXProduct = vectorToRotate.x * cameraRight;

        Vector3 vectorRotatedToCameraSpace = cameraForwardZproduct + cameraRightXProduct;
        vectorRotatedToCameraSpace.y = currentYValue;
        return vectorRotatedToCameraSpace;
    }

    private void RotationHandler()
    {
        float rotationFactorPerFrame = 10;
        Vector3 positionToLookAt;
        positionToLookAt.x = cameraRelativeMovement.x;
        positionToLookAt.y = 0f;
        positionToLookAt.z = cameraRelativeMovement.z;
        Quaternion currentRotation = transform.rotation;

       // if (isMoving)
       // {
       //     Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
       //     transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
       // }
    }

    private void GetAnimatorParameters()
    {

        isJumpingHash = Animator.StringToHash("isJumping");
        velocityHash = Animator.StringToHash("velocity");
    }

    private void OnEnable()
    {
       // playerControl.Enable();
    }

    private void OnDisable()
    {
     //   playerControl.Disable();
    }
}
