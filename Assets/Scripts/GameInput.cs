using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnInteractAction;

    PlayerInputActions playerInputActions;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Entered Interact");
        if(OnInteractAction != null)
        {
            OnInteractAction(this, EventArgs.Empty);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        // Debug.Log(inputVector*Time.deltaTime);

        return new Vector3(inputVector.x, 0, inputVector.y);
    }
}
