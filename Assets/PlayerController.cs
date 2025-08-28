using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float ForwardSpeed;
    public float MaxSpeed;
    private int desiredLane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    public float Gravity = -20;  // Increased gravity for smoother landing
    public float laneSwitchSpeed = 10f;
    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        animator.SetBool("isGameStarted", true);

        if (ForwardSpeed < MaxSpeed)
        {
            ForwardSpeed += 0.1f * Time.deltaTime;
        }

        direction.z = ForwardSpeed;

        // Handle jumping and grounding
        if (controller.isGrounded)
        {
            direction.y = 0; // Set to 0 for smoother grounding
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime; // Apply gravity
        }

        // Lane switching logic
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane = Mathf.Min(desiredLane + 1, 2); // Limits to the right-most lane
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane = Mathf.Max(desiredLane - 1, 0); // Limits to the left-most lane
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        controller.Move(moveDir.sqrMagnitude < diff.sqrMagnitude ? moveDir : diff);
    }

    private void FixedUpdate()
    {
        // Apply direction (including forward speed and gravity) in FixedUpdate
        controller.Move(direction * Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            Debug.Log("Player hit an obstacle!");
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("Game Over");
        }
    }
}
