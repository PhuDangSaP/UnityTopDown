using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    private float speed;
    public float moveSpeed = 10f;
    public float sprintSpeed = 20f;
    public float crouchSpeed = 5f;

    private bool isCrouching;
    public bool isAiming;

    private Vector3 moveDirection;


    private Vector3 lookPos;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        speed = moveSpeed;

    }
    void Update()
    {
        MoveThePlayer();
        Sprint();
        Crouch();
        Aim();
     
    }
    void MoveThePlayer()
    {
        animator.SetBool("isMoving", false);
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }

        moveDirection *= speed * Time.deltaTime;
        characterController.Move(moveDirection);

        float velocityZ = Vector3.Dot(moveDirection.normalized, transform.forward);
        float velocityX = Vector3.Dot(moveDirection.normalized, transform.right);
        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }


    private void Aim()
    {
        if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.LeftControl))
            isAiming = false;
        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftControl))
            isAiming = true;

        if (!isAiming)
            return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            lookPos = raycastHit.point;
        }
        else
        {
            lookPos = ray.GetPoint(999);
        }
        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
        
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            speed = sprintSpeed;
            animator.SetBool("isSprinting", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            speed = moveSpeed;
            animator.SetBool("isSprinting", false);
        }
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                speed = moveSpeed;
                isCrouching = false;
                animator.SetBool("isCrouching", isCrouching);              
            }
            else
            {              
                speed = crouchSpeed;
                isCrouching = true;                             
                animator.SetBool("isCrouching", isCrouching);
            }
        }
    }


}
