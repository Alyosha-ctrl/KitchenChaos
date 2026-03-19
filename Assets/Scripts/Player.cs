using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;

    public GameInput gameInput;
    private bool isWalking = false;

    private Vector3 lastInteractDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        
    }

    // Update is called once per frame
     private void Update()
    {
        Movement();
        if (Keyboard.current.eKey.isPressed)
        {
            Interaction();
        }
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
            
            if(hit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has component
                clearCounter.Interact();
            }
        }
    }
}
