using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpPower;

    [Header("Camera")]
    public float camXRotate;
    public Vector2 mousedelta;
    public float cameraSensitivity;
    public Transform cameraContainer;
    public float minXRotate;
    public float maxXRotate;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
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

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mousedelta = context.ReadValue<Vector2>();
    }

    private void CameraLook()
    {
        camXRotate += mousedelta.y * cameraSensitivity;
        camXRotate = Mathf.Clamp(camXRotate, minXRotate, maxXRotate);   //���Ʒ� ȭ�� ������ ����
        cameraContainer.localEulerAngles = new Vector3(-camXRotate, 0, 0);
        transform.eulerAngles += new Vector3(0, mousedelta.x * cameraSensitivity, 0);
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
        dir.y = rb.velocity.y;  // �����ָ� �����Ҷ� ŹŹ ����� ����ó�� õõ�� ������
        rb.velocity = dir;
    }
}
