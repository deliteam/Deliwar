using System;
using System.Collections;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Code.EnemyDog
{
    public enum EnemyState
    {
        None,
        Idle,
        Walk,
        Attack,
        Die
    }

    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private EnemyState _state;
        [SerializeField] private EnemyPatrolling _patrolling;
        public float playerChaseRange = 10;
        public float playerAttackRange = 2;
        public float attackInterval = 0.5f;
        public float hurtTimeAfterAttack = 0.5f;
        private float lastAttackTime;
        public float speed = 2;
        private bool _isPlayerInChaseRange;
        private PlayerScript _foundPlayer;
        public float knockbackDistance = 2f;
        private bool isDead = false;

        private Collider2D collider;

        private void Awake()
        {
            collider = GetComponent<BoxCollider2D>();
            healthBar.OnDead += OnDead;
        }

        private void OnDead()
        {
            isDead = true;
            collider.enabled = false;
            _animator.SetDeadAnim();
        }

        private void OnDestroy()
        {
            healthBar.OnDead -= OnDead;
        }

        private void Update()
        {
            if (isDead)
            {
                return;
            }

            lastAttackTime += Time.deltaTime;
            CheckPlayer();
            _patrolling.isActive = !_isPlayerInChaseRange;
            if (!_isPlayerInChaseRange)
            {
                _animator.SetWalkAnim();
            }

            if (_isPlayerInChaseRange)
            {
                if (_foundPlayer.transform.position.x < transform.position.x)
                {
                    transform.localScale = Vector3.one;
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                if (Vector2.Distance(_foundPlayer.transform.position, transform.position) < playerAttackRange)
                {
                    if (lastAttackTime > attackInterval)
                    {
                        _animator.SetAttackAnim();
                        lastAttackTime = 0;
                        StartCoroutine(HurtPlayer());
                    }
                }
                else
                {
                    _animator.SetWalkAnim();
                    transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(_foundPlayer.transform.position.x, transform.position.y), speed * Time.deltaTime);
                }
            }
        }

        private IEnumerator HurtPlayer()
        {
            yield return new WaitForSeconds(hurtTimeAfterAttack);
            _foundPlayer.GetHurt();
        }

        public void GetHurt(Transform from)
        {
            float knockback = knockbackDistance;
            if (from.transform.position.x > transform.position.x)
            {
                knockback = knockback * -1;
            }

            healthBar.SetDamage(15);
            transform.position =
                new Vector3(transform.position.x + knockback, transform.position.y, transform.position.z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, playerChaseRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerAttackRange);
        }

        private void CheckPlayer()
        {
            var col = Physics2D.OverlapCircle(transform.position, playerChaseRange,
                LayerConstants.PlayerLayerMask);

            if (col)
            {
                _foundPlayer = col.GetComponent<PlayerScript>();
                if (_foundPlayer)
                {
                    _isPlayerInChaseRange = true;
                    return;
                }
            }

            _foundPlayer = null;
            _isPlayerInChaseRange = false;
        }
    }
}