using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float maxSpeed;

    private int desiredLane = 1; //0:izquierda, 1:centro, 2:derecha
    [SerializeField] private float laneDistance = 2.5f; //La distancia entre carriles de remolque

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float gravity = -12f;
    [SerializeField] private float jumpHeight = 2;
    private Vector3 velocity;

    [SerializeField] private Animator animator;
    private bool isSliding = false;

    [SerializeField] private float slideDuration = 1.5f;

    bool toggle = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
        {
            return;
        }

        //Incrementa la velocidad
        if (toggle)
        {
            toggle = false;
            if (forwardSpeed < maxSpeed)
            {
                forwardSpeed += 0.1f * Time.fixedDeltaTime;
            }
        }
        else
        {
            toggle = true;
            if (Time.timeScale < 2f)
            {
                Time.timeScale += 0.005f * Time.fixedDeltaTime;
            }
        }
    }

    private void Update()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
        {
            return;
        }

        animator.SetBool("isGameStarted", true);
        move.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        if (Application.isMobilePlatform)
        {
            if (isGrounded)
            {
                if (SwipeManager.swipeUp)
                    Jump();

                if (SwipeManager.swipeDown && !isSliding)
                    StartCoroutine(Slide());
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
                if (SwipeManager.swipeDown && !isSliding)
                {
                    StartCoroutine(Slide());
                    velocity.y = -10;
                }

            }
            controller.Move(velocity * Time.deltaTime);

            //Recopilar las aportaciones sobre qué carril debería seguir
            if (SwipeManager.swipeRight)
            {
                desiredLane++;
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }
            }

            if (SwipeManager.swipeLeft)
            {
                desiredLane--;
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }
            }
        }
        else
        {
            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    Jump();

                if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding)
                    StartCoroutine(Slide());
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding)
                {
                    StartCoroutine(Slide());
                    velocity.y = -10;
                }

            }
            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.D))
            {
                desiredLane++;
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                desiredLane--;
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }
            }
        }

        //Calcular dónde debería estar en el futuro
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }

        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = targetPosition;
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
            {
                controller.Move(moveDir);
            }

            else
            {
                controller.Move(diff);
            }
        }

        controller.Move(move * Time.deltaTime);
    }

    private void Jump()
    {   
        StopCoroutine(Slide());
        animator.SetBool("isSliding", false);
        animator.SetTrigger("jump");
        controller.center = Vector3.zero;
        controller.height = 2;
        isSliding = false;
   
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        yield return new WaitForSeconds(0.25f/ Time.timeScale);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds((slideDuration - 0.25f)/Time.timeScale);

        animator.SetBool("isSliding", false);

        controller.center = Vector3.zero;
        controller.height = 2;

        isSliding = false;
    }
}
