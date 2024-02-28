using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public Transform playerVisual;
    public float moveSpeed = 3f;
    public float lrSpeed = 9f;
    public float rotationSpeed = 180f;
    public float jumpForce = 10f;
    public float crouchScale = 0.5f;
  //  public Transform groundCheck;
    public LayerMask groundMask;
    public CapsuleCollider capsuleCollider;

    private bool isGrounded;

    void Update()
    {
        // Keep moving forward continuously
        // Vector3 moveDirection = transform.forward * moveSpeed;
        // playerRigid.MovePosition(transform.position + moveDirection * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.W))  //&& isGrounded
        {
            playerRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("jump");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
           
            playerAnim.SetTrigger("run");
        }



        if (Input.GetKeyDown(KeyCode.Space) )
        {
          
            playerAnim.SetTrigger("flip");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            playerAnim.SetTrigger("run");
        }




        // Check for crouch input
        if (Input.GetKeyDown(KeyCode.S))
        {
          //  transform.localScale = new Vector3(1f, crouchScale, 1f);
            playerAnim.SetTrigger("slide");
            capsuleCollider.height = 0.8258972f;
            capsuleCollider.center = new Vector3(0.006896973f, -0.423111f, 0.1062469f);
            Debug.Log(capsuleCollider.height);
            Debug.Log(capsuleCollider.center);


        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
           // transform.localScale = Vector3.one;
            playerAnim.SetTrigger("run");
            capsuleCollider.height = 1.916809f;
            capsuleCollider.center = new Vector3(0.006896973f, 0.03842163f, 0.1062469f);
        }

        // Check for left/right movement input
      //  float horizontal = Input.GetAxis("Horizontal");
      //  float vertical = Input.GetAxis("Vertical");

       

        // Move left or right based on 'A' and 'D' keys
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate( Vector3.left * Time.deltaTime * lrSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // playerRigid.MovePosition(transform.position + Vector3.right * moveSpeed * Time.deltaTime );

            transform.Translate(Vector3.left * Time.deltaTime * lrSpeed * -1);

        }
    }

  //  void FixedUpdate()
   // {
    //    isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
   // }
}
