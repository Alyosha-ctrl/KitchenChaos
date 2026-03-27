using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Transform kitchenObjectHoldPoint;
    public GameInput gameInput;
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    public static Player Instance {get; private set;}

    private bool isWalking = false;
    private Vector3 lastInteractDir;
    private BaseCounter selectedCounter;
    private kitchenObject kitchenObject;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Error second player");
        }
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Interaction();
    }

    // Update is called once per frame
     private void Update()
    {
        Movement();
        Interaction();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void Movement()
    {
        Vector3 moveDir = gameInput.GetMovementVectorNormalized();

        float playerWidth = .7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up*2, playerWidth, moveDir, moveSpeed*Time.deltaTime);

        // Debug.Log(canMove);

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;

        transform.forward =  Vector3.Slerp(transform.forward, moveDir, Time.deltaTime*rotateSpeed);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up*2, playerWidth, moveDirX, moveSpeed*Time.deltaTime);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up*2, playerWidth, moveDirZ, moveSpeed*Time.deltaTime);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        // Debug.Log(canMove);

        if (canMove)
        {
            transform.position += moveDir * moveSpeed *Time.deltaTime ;
        }

        // Debug.Log(moveDir);
    }

    private void Interaction()
    {
        Vector3 moveDir = gameInput.GetMovementVectorNormalized();

        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        bool canInteract = Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hit, interactDistance);

        // Debug.Log(hit);

        if (canInteract)
        {
            
            if(hit.transform.TryGetComponent(out BaseCounter clearCounter))
            {
                if(clearCounter != selectedCounter) selectedCounter = clearCounter;
                //Has component
                if (Keyboard.current.eKey.IsActuated())
                {
                    Debug.Log("interacted");
                    clearCounter.Interact(this);
                }
                SetSelectedCounter(selectedCounter);
            }
            else
            {
                selectedCounter = null;
                SetSelectedCounter(null);
            }
        }
        else
        {
            selectedCounter = null;
            SetSelectedCounter(null);
        }
    }

    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
                {
                    selectedCounter = selectedCounter
                });

    }

    public Transform GetSpawnPosition()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(kitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public kitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
