using UnityEngine;

namespace Code.EnemyDog
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const string WalkParam = "Walk";
        private const string IdleParam = "Idle";
        private const string AttackParam = "Attack";
        private const string DeadParam = "Dead";

        private static readonly int WalkParamId = Animator.StringToHash(WalkParam);
        private static readonly int IdleParamId = Animator.StringToHash(IdleParam);
        private static readonly int AttackParamId = Animator.StringToHash(AttackParam);
        private static readonly int DeadParamId = Animator.StringToHash(DeadParam);

        [SerializeField] private Animator animator;

        public void SetIdleAnim()
        {
            animator.SetBool(IdleParamId, true);
            animator.SetBool(WalkParamId, false);
            animator.SetBool(AttackParamId, false);
        }

        public void SetWalkAnim()
        {
            animator.SetBool(IdleParamId, false);
            animator.SetBool(WalkParamId, true);
            animator.SetBool(AttackParamId, false);
        }

        public void SetAttackAnim()
        {
            animator.SetBool(IdleParamId, false);
            animator.SetBool(WalkParamId, false);
            animator.SetBool(AttackParamId, true);
        }

        public void SetDeadAnim()
        {
          
            animator.SetTrigger(DeadParamId);
        }
    }
}