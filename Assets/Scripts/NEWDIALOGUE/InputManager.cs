using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script acts as a single point for all other scripts to get
// the current input from. It uses Unity's new Input System and
// functions should be mapped to their corresponding controls
// using a PlayerInput component with Unity Events.

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private bool jumpPressed = false;
    private bool interactPressed = false;
    private bool submitPressed = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    // The GetInstance method allows other scripts to access this singleton instance.
    public static InputManager GetInstance()
    {
        return instance;
    }

    // MovePressed is called when the player moves their character, updating the moveDirection.
    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    // JumpPressed is called when the player presses or releases the jump button.
    public void JumpPressed(InputAction.CallbackContext context)
    {
        jumpPressed = context.performed;
    }

    // InteractButtonPressed is called when the player presses or releases the interact button.
    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        interactPressed = context.performed;
    }

    // SubmitPressed is called when the player presses or releases the submit button.
    public void SubmitPressed(InputAction.CallbackContext context)
    {
        submitPressed = context.performed;
    }

    // GetMoveDirection returns the current moveDirection value.
    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    // GetJumpPressed returns whether the jump button was pressed and resets the jumpPressed flag.
    public bool GetJumpPressed()
    {
        bool result = jumpPressed;
        jumpPressed = false;
        return result;
    }

    // GetInteractPressed returns whether the interact button was pressed and resets the interactPressed flag.
    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    // GetSubmitPressed returns whether the submit button was pressed and resets the submitPressed flag.
    public bool GetSubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    // RegisterSubmitPressed is a method to manually reset the submitPressed flag.
    public void RegisterSubmitPressed()
    {
        submitPressed = false;
    }
}
