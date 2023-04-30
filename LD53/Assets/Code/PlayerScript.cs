using Code;
using UnityEngine;

public enum PlayerMoveState
{
    None,
    Idle,
    Walk,
    Jump
}
public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] private PlayerMoveState _playerMoveState;
    public Animator[] Animators;
    public Rigidbody2D rb; 
    public float speed = 5f; 
    public float jumpForce = 10f; 
    public float groundCheckDistance = 1f;
    float horizontalInput;
    bool jumpInput;

    public bool isGrounded = false;

    void Update()
    {
        CheckGround();
        horizontalInput = Input.GetAxis("Horizontal"); // yatay girdi (A ve D tuşları veya sol ve sağ oklar)
        jumpInput = Input.GetKeyDown(KeyCode.Space); // zıplama girdisi (boşluk tuşu)
    
            
       if (jumpInput && isGrounded) 
       {
           rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);  
       }

       if (!isGrounded && _playerMoveState != PlayerMoveState.Jump)
       {
           _playerMoveState = PlayerMoveState.Jump;
           foreach (var animator in Animators)
           {
               animator.SetTrigger("Jump");
           }
       }
       else if (horizontalInput == 0 && _playerMoveState != PlayerMoveState.Idle)
       {
           _playerMoveState = PlayerMoveState.Idle;
           foreach (var animator in Animators)
           {
               animator.SetTrigger("Idle");
           }
       }
       else if(horizontalInput != 0 && _playerMoveState != PlayerMoveState.Walk)
       {
           _playerMoveState = PlayerMoveState.Walk;
           foreach (var animator in Animators)
           {
               animator.SetTrigger("Walk");
           }
       }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckDistance);
    }

    private void CheckGround()
    {
        var col = Physics2D.OverlapCircle(transform.position, groundCheckDistance,
            LayerConstants.GroundLayerMask);
        if (col != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.velocity; 
        position.x = horizontalInput * speed;
        rb.velocity = position; 
    }
}