using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isGrounded;
    private bool isJumping = false;
    [HideInInspector] public bool isSliding = false;
    public enum WalkRoad { LEFT, MIDDLE, RIGHT }
    public WalkRoad walkRoad;
    [SerializeField] private Transform feetPose;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatGround;
    private Animator anim;
    private Rigidbody rb;
    private Vector3 moveDir = Vector3.zero;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(feetPose.position, groundCheckRadius, whatGround);
        if(Input.GetKeyDown(KeyCode.Space)) Jumping();
        switch(walkRoad)
        {
            case WalkRoad.LEFT:
                moveDir = new Vector3(-1f, transform.position.y, transform.position.z);
                break;
            case WalkRoad.RIGHT:
                moveDir = new Vector3(1f, transform.position.y, transform.position.z);
                break;
            case WalkRoad.MIDDLE:
                moveDir = new Vector3(0f, transform.position.y, transform.position.z);
                break;
        }
        transform.position = Vector3.MoveTowards(transform.position, moveDir, speed * Time.deltaTime);
    }
    public void LeftButt()
    {
        //if(!isGrounded) return;
        if(walkRoad == WalkRoad.MIDDLE) walkRoad = WalkRoad.LEFT;
        if(walkRoad == WalkRoad.RIGHT) walkRoad = WalkRoad.MIDDLE;
    }
    public void RightButt()
    {
        //if(!isGrounded) return;
        if(walkRoad == WalkRoad.MIDDLE) walkRoad = WalkRoad.RIGHT;
        if(walkRoad == WalkRoad.LEFT) walkRoad = WalkRoad.MIDDLE;
    }
    private void FixedUpdate()
    {
        if(isGrounded && isJumping)
        {
            rb.velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }
    public void Jumping() => isJumping = !isJumping;
    public void Slide()
    {
        
        if(!isSliding) anim.SetTrigger("slide");
        isSliding = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Wall")) GameManager.instance.Lose();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; Gizmos.DrawWireSphere(feetPose.position, groundCheckRadius);
    }
}
