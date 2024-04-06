using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform groundObj;
    [SerializeField] LayerMask groundMask;
    readonly float distance = 0.2f;
    
    readonly float fallMultiplier = 2.5f; 
    readonly float lowJumpMultiplier = 2f;
    
    private bool Grounded;
    [HideInInspector]public bool canMove = true;

    float Speed {  get; set; }
    float Jump { get; set; }

    public enum Gravity{
        UP, DOWN
    }

    [HideInInspector]public Gravity gravity;

    [HideInInspector]public float AbilityDuration = -1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Speed = 3;
        Jump = 10;
        gravity = Gravity.UP;
    }

    private void Update()
    {
        if (!canMove) { return; }

        Movement();
        if(AbilityDuration > -1) { TimedAbilities(); }
    }

    private void TimedAbilities()
    {
        AbilityDuration -= Time.deltaTime;
        if(AbilityDuration < 0)
        {
            transform.localScale = Vector3.one;
        }
    }

    private void Movement()
    {
        //Movement
        if (gravity == Gravity.UP)
        {
            if (Input.GetAxis("Horizontal") > 0) { rb.AddForce(Vector3.right * Speed); }
            if (Input.GetAxis("Horizontal") < 0) { rb.AddForce(-Vector3.right * Speed); }
            if (Input.GetAxis("Vertical") > 0) { rb.AddForce(Vector3.forward * Speed); }
            if (Input.GetAxis("Vertical") < 0) { rb.AddForce(-Vector3.forward * Speed); }
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0) { rb.AddForce(-Vector3.right * Speed); }
            if (Input.GetAxis("Horizontal") < 0) { rb.AddForce(Vector3.right * Speed); }
            if (Input.GetAxis("Vertical") > 0) { rb.AddForce(Vector3.forward * Speed); }
            if (Input.GetAxis("Vertical") < 0) { rb.AddForce(-Vector3.forward * Speed); }
        }

        JumpM();
    }

    private void JumpM()
    {
        //Jump
        groundObj.transform.position = transform.position - (Vector3.up / 2);
        Grounded = Physics.CheckSphere(groundObj.position, distance, groundMask);
        if (Input.GetButtonDown("Jump") && Grounded) { rb.AddForce(Vector3.up * Jump, ForceMode.Impulse); }
        if (rb.velocity.y < 0) { rb.velocity += (fallMultiplier - 1) * Physics.gravity.y * Time.deltaTime * Vector3.up; }
        else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump")) { rb.velocity += (lowJumpMultiplier - 1) * Physics.gravity.y * Time.deltaTime * Vector3.up; } 
    }
}
