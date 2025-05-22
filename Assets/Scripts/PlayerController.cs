using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpPower;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + transform.right*0.2f + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + -transform.right*0.2f + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + transform.forward*0.2f + transform.up * 0.01f, Vector3.down),
            new Ray(transform.position + -transform.forward*0.2f + transform.up * 0.01f, Vector3.down)
        };
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, LayerMask.GetMask("Ground")))
            {
                return true;
            }
        }
        return false;
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;  // ¾ÈÇØÁÖ¸é Á¡ÇÁÇÒ¶§ Å¹Å¹ ²÷±â°í ±êÅÐÃ³·³ ÃµÃµÈ÷ ³»·Á¿È
        rb.velocity = dir;
    }
}
