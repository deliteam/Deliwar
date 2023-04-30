using System;
using System.Collections;
using Code;
using UnityEngine;

public enum PlayerMoveState
{
    None,
    Idle,
    Walk,
    Run,
    Jump,
    Attack,
    Hurt
}

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerPackageController _packageController;

    [SerializeField] private PlayerMoveState _playerMoveState;
    public Rigidbody2D rb;
    public float speed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 1f;
    public float attackInterval = 0.5f;

    private float _currentAttackInterval;
    float horizontalInput;
    bool jumpInput;
    bool isRunning;
    bool isAttacking;

    public bool isGrounded = false;

    private void Awake()
    {
        _packageController.OnPackageContainerChanged += OnPackageContainerChanged;
    }

    private void OnPackageContainerChanged()
    {
        SetAnimation();
    }

    private void OnDestroy()
    {
        _packageController.OnPackageContainerChanged -= OnPackageContainerChanged;
    }

    private void Update()
    {
        _currentAttackInterval += Time.deltaTime;
        CheckGround();
        SetInputParams();
        CheckFlip();
        CheckJumpAction();
        CheckState();

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StopAllCoroutines();
            StartCoroutine(GetHurt());
        }
    }

    private IEnumerator GetHurt()
    {
        _playerAnimator.SetDamagedAnim();
        _packageController.RemovePackage();
        yield return null;
        _playerMoveState = PlayerMoveState.Hurt;
    }

    private void CheckFlip()
    {
        if (horizontalInput > 0.1f)
        {
            transform.localRotation = Quaternion.identity;
        }
        else if (horizontalInput < -0.1f)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    private void CheckState()
    {
        if (isAttacking && _playerMoveState != PlayerMoveState.Attack)
        {
            _playerMoveState = PlayerMoveState.Attack;
            SetAnimation();
        }
        else if (!isGrounded && _playerMoveState != PlayerMoveState.Jump)
        {
            _playerMoveState = PlayerMoveState.Jump;
            SetAnimation();
        }
        else if (horizontalInput == 0 && _playerMoveState != PlayerMoveState.Idle && isGrounded)
        {
            _playerMoveState = PlayerMoveState.Idle;
            SetAnimation();
        }
        else if (horizontalInput != 0 && _playerMoveState != PlayerMoveState.Walk && isGrounded && !isRunning)
        {
            _playerMoveState = PlayerMoveState.Walk;
            SetAnimation();
        }
        else if (horizontalInput != 0 && _playerMoveState != PlayerMoveState.Run && isGrounded && isRunning)
        {
            _playerMoveState = PlayerMoveState.Run;
            SetAnimation();
        }
    }

    private void SetAnimation()
    {
        switch (_playerMoveState)
        {
            case PlayerMoveState.None:
            case PlayerMoveState.Idle:
                _playerAnimator.SetIdleAnim();
                break;
            case PlayerMoveState.Walk:
                _playerAnimator.SetWalkAnim();
                break;
            case PlayerMoveState.Run:
                _playerAnimator.SetRunAnim();
                break;
            case PlayerMoveState.Jump:
                _playerAnimator.SetJumpAnim();
                break;
            case PlayerMoveState.Attack:
                _playerAnimator.SetMeleeAttackAnim();
                break;
            case PlayerMoveState.Hurt:
                _playerAnimator.SetDamagedAnim();
                break;
            default:
                _playerAnimator.SetIdleAnim();
                break;
        }
    }

    private void CheckJumpAction()
    {
        if (jumpInput && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void SetInputParams()
    {
        if (Input.GetKeyDown(KeyCode.F) && _currentAttackInterval > attackInterval)
        {
            isAttacking = true;
            _currentAttackInterval = 0;
        }
        else if (_currentAttackInterval < attackInterval)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        if (isAttacking)
        {
            horizontalInput = 0;
            isRunning = false;
            jumpInput = false;
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);
        isRunning = Input.GetKey(KeyCode.LeftShift);
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
        position.x = horizontalInput * (isRunning ? runSpeed : speed);
        rb.velocity = position;
    }
}