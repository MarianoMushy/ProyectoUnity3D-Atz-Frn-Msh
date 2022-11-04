using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float speed = 6f;

    public Transform groundCheck;
    public LayerMask groundMask;

    public float gravity = -9.81f;
    public float groundDistance = .2f;

    private Vector3 velocity;
    private bool isGrounded;

    public float jump = 3f;


    public Vector3 moveDir;

    public float salto = 1;

    private float coyoteTime = 0.14f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.16f;
    private float jumpBufferCounter;

    public GameObject footstep;

    //AnimacionesTest
    private Animator anim;

    private void Awake()
    {
        footstep.SetActive(false);
        anim = transform.GetChild(0).GetComponent<Animator>();
    }


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        if ((isGrounded))
        {
            anim.SetBool("Caida", false);

            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            anim.SetBool("Caida", true);
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (isGrounded && direction.magnitude >= 0.1f)
        {
            anim.SetBool("Run", true);
            footsteps();
        }
        else
        {
            StopFootsteps();
            anim.SetBool("Run", false);
           
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime); 
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            Jump(salto);
            jumpBufferCounter = 0;
        }

        if (Input.GetButtonUp("Jump"))
        {
            coyoteTimeCounter = 0f;
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump(float salto)
    {
        anim.SetTrigger("Jump");
        velocity.y = Mathf.Sqrt(jump * -2.0f * gravity) * salto;
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }

}
