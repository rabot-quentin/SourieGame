/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement_V2 : MonoBehaviour
{
    public float speed = 10f; //Controls velocity multiplier

    Rigidbody rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
    }


    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove) * speed; // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 


    }
}*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;
    public GameObject characterHolder;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 0.6f;
    public Vector3 colliderOffset;

    // Update is called once per frame
    void Update()
    {
        bool wasOnGround = onGround;
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

        if (!wasOnGround && onGround)
        {
            StartCoroutine(JumpSqueeze(1.25f, 0.8f, 0.05f));
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }
        animator.SetBool("onGround", onGround);
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        moveCharacter(direction.x);
        if (jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        modifyPhysics();
    }
    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("vertical", rb.velocity.y);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
        StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
    }
    void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement_V2 : MonoBehaviour
{ 
    public CharacterController controller;
    public Transform cam;

    //public Rigidbody rb;
    //public bool ground = true;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        /*
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime );
        }
        */

/*   transform.Translate(direction * Time.deltaTime * speed);


}
}*/


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement_V2 : MonoBehaviour
{
    public Transform trf;
    public float movementSpeed = 1f;
    public float jumpPower = 10f;

    public float gravityFactor = -9.81f;
    public float currentVelY = 0;

    public bool isSprinting = false;
    public float sprintingMultiplier;

    public CharacterController controller;

    public LayerMask groundMask;
    public Transform groundDetectionTransform;
    public Rigidbody rig;
    public bool isGrounded;
    public Collider[] cols;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rig = GetComponent<Rigidbody>();
        trf = GetComponent<Transform>();
    }

    public void CheckIsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.distance);
            if (hit.distance < 1.5f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;


            }
            /*cols = Physics.OverlapSphere(groundDetectionTransform.position, 0.05f, groundMask);

        if (cols.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }*/
   /*     }
    }
        void Update()
        {

            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            CheckIsGrounded();

            if (isGrounded == false)
            {
                //currentVelY += gravityFactor * Time.deltaTime;
            }
            else if (isGrounded == true)
            {
                //currentVelY = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
            Debug.Log("saut");
            trf.position = new Vector3(trf.position.x, 10,trf.position.z);
            controller.SimpleMove(new Vector3(0, 10, 0));
            
                   //rig.AddForce(new Vector3(0,1000000000000,0));
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }

            Vector3 movement = new Vector3();

            movement = inputX * transform.right + inputY * transform.forward;

            if (isSprinting == true)
            {
                movement *= sprintingMultiplier;
            }

            controller.Move(movement * movementSpeed * Time.deltaTime);
            controller.Move(new Vector3(0, currentVelY * Time.deltaTime, 0));
        }
    
}*/
