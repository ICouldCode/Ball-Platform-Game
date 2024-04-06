using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform groundObj;
    [SerializeField] LayerMask groundMask;
    readonly float distance = 0.2f;
    
    float fallMultiplier = 2.5f; 
    float lowJumpMultiplier = 2f;
    bool Grounded;

    float Speed {  get; set; }
    float Jump { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Speed = 3;
        Jump = 10;
    }

    private void Update()
    {
        //Movement
        if(Input.GetAxis("Horizontal") > 0) { rb.AddForce(Vector3.right * Speed); }
        if (Input.GetAxis("Horizontal") < 0) { rb.AddForce(-Vector3.right * Speed); }
        if (Input.GetAxis("Vertical") > 0) { rb.AddForce(Vector3.forward * Speed); }
        if (Input.GetAxis("Vertical") < 0) { rb.AddForce(-Vector3.forward * Speed); }

        //Jump
        groundObj.transform.position = transform.position - (Vector3.up / 2);
        Grounded = Physics.CheckSphere(groundObj.position, distance, groundMask);
        if (Input.GetButtonDown("Jump") && Grounded) { rb.AddForce(Vector3.up * Jump, ForceMode.Impulse); }
        if (rb.velocity.y < 0) { rb.velocity += (fallMultiplier - 1) * Physics.gravity.y * Time.deltaTime * Vector3.up; }
        else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump")) { rb.velocity += (lowJumpMultiplier - 1) * Physics.gravity.y * Time.deltaTime * Vector3.up; }
    }
}
