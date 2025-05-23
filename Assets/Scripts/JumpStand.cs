using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStand : MonoBehaviour
{
    public float jumpStandPower;
    Rigidbody rb;


    public void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();

        Vector3 vector3 = rb.velocity;  //일정하게 점프 안해서 y값만 초기화
        vector3.y = 0f;
        rb.velocity = vector3;

        rb.AddForce(Vector3.up * jumpStandPower, ForceMode.Impulse);

    }
}
