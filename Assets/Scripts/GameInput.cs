using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnInteractAction;

    PlayerInputActions playerInputActions;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    // void Start()
    // {
        
    // }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Entered Interact");
        
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        // float blah = playerInputActions.Player.Interact.ReadValue<float>();
        // Debug.Log(blah);
    }

    public Vector3 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        // Debug.Log(inputVector*Time.deltaTime);

        return new Vector3(inputVector.x, 0, inputVector.y);
    }
}
