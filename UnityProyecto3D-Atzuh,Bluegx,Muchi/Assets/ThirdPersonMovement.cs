using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float speed = 6f;

    private Vector3 moveDir;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f && groundedPlayer)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        else if(direction.magnitude <= 0.1f && groundedPlayer)
        {
            moveDir = Vector3.zero;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer && direction.magnitude == 0f)
        {
            moveDir = Vector3.zero;
            moveDir.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
       else if (Input.GetButtonDown("Jump") && groundedPlayer && direction.magnitude >= 0.1f)
        {
            moveDir.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        moveDir.y += gravityValue * Time.deltaTime;
        controller.Move(moveDir.normalized * speed * Time.deltaTime);
    }
}
