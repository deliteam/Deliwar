using System;
using DG.Tweening;
using UnityEngine;

namespace Code.EnemyDog
{
    public enum EnemyState{
        None,
        Idle,
        Walk,
        Attack,
        Die
    }
    
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyState _state;
        [SerializeField] private EnemyPatrolling _patrolling;
        public float playerChaseRange = 10;
        public float playerAttackRange = 2;
        public float attackInterval = 0.5f;
        private float lastAttackTime;
        public float speed = 2;
        private bool _isPlayerInChaseRange;
        private PlayerScript _foundPlayer;
        public float knockbackDistance = 2f;
        private void Update()
        {
            lastAttackTime += Time.deltaTime;
            CheckPlayer();
            _patrolling.isActive = !_isPlayerInChaseRange;

            if (_isPlayerInChaseRange)
            {
                if (Vector2.Distance(_foundPlayer.transform.position, transform.position) < playerAttackRange)
                {
                    if (lastAttackTime > attackInterval)
                    {
                        lastAttackTime = 0;
                        _foundPlayer.GetHurt();
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(_foundPlayer.transform.position.x,transform.position.y), speed * Time.deltaTime);
                }
            }
        }

        public void GetHurt()
        {
            transform.position = new Vector3(transform.position.x + knockbackDistance, transform.position.y, transform.position.z);
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