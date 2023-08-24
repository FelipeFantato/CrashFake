using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private CharacterController characterController;
    private PlayerMovementComponent movementComponent;
    private Transform playerTransform;
    private bool isJumping;
    private bool isMoving;

    [SerializeField] private float jumpHeight = 1;
    [SerializeField] private float velocity = 10;
    [SerializeField] private int lives = 1;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
           Destroy(this.gameObject);
        }
        #endregion

        movementComponent = GetComponent<PlayerMovementComponent>();
        playerTransform = GetComponent<Transform>();
        InputManager.onMove += MovePlayer;

        characterController = GetComponent<CharacterController>();
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
       movementComponent.MovePlayer(context);
    }

    public bool GetIsMoving() { return isMoving; }

    public void SetIsMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    public float GetPlayerVelocity()
    {
        return velocity;
    }

    public float GetCurrentVelocity()
    {
        return characterController.velocity.magnitude;
    }

    private void OnDisable()
    {
        InputManager.onMove -= MovePlayer;
    }

}
