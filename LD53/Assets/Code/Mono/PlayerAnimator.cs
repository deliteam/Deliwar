using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Code
{
    public class PlayerAnimator : MonoBehaviour
    {
        private const string DamagedParam = "Damaged";
        private const string MeleeAttackParam = "MeleeAttack";
        private const string RunParam = "Run";
        private const string WalkParam = "Walk";
        private const string IdleParam = "Idle";
        private const string JumpParam = "Jump";
        
        private static readonly int DamagedParamId = Animator.StringToHash(DamagedParam);
        private static readonly int MeleeAttackParamId = Animator.StringToHash(MeleeAttackParam);
        private static readonly int RunParamId = Animator.StringToHash(RunParam);
        private static readonly int WalkParamId = Animator.StringToHash(WalkParam);
        private static readonly int IdleParamId = Animator.StringToHash(IdleParam);
        private static readonly int JumpParamId = Animator.StringToHash(JumpParam);

        [SerializeField] private Animator[] _animators;

        public void SetDamagedAnim()
        {
            foreach (var animator in _animators)
            {
                animator.SetBool(DamagedParamId,true);
                animator.SetBool(MeleeAttackParamId,false);
                animator.SetBool(RunParamId,false);
                animator.SetBool(WalkParamId,false);
                animator.SetBool(IdleParamId,false);
                animator.SetBool(JumpParamId,false);
            }
        }
        
        public void SetMeleeAttackAnim()
        {
            foreach (var animator in _animators)
            {
                animator.SetBool(DamagedParamId,false);
                animator.SetBool(MeleeAttackParamId,true);
                animator.SetBool(RunParamId,false);
                animator.SetBool(WalkParamId,false);
                animator.SetBool(IdleParamId,false);
                animator.SetBool(JumpParamId,false);
            }
        }
        
        public void SetRunAnim()
        {
            foreach (var animator in _animators)
            {
                animator.SetBool(DamagedParamId,false);
                animator.SetBool(MeleeAttackParamId,false);
                animator.SetBool(RunParamId,true);
                animator.SetBool(WalkParamId,false);
                animator.SetBool(IdleParamId,false);
                animator.SetBool(JumpParamId,false);
            }
        }
        
        public void SetWalkAnim()
        {
            foreach (var animator in _animators)
            {
                animator.SetBool(DamagedParamId,false);
                animator.SetBool(MeleeAttackParamId,false);
                animator.SetBool(RunParamId,false);
                animator.SetBool(WalkParamId,true);
                animator.SetBool(IdleParamId,false);
                animator.SetBool(JumpParamId,false);
            }
        }
        
        public void SetIdleAnim()
        {
            foreach (var animator in _animators)
            {
                animator.SetBool(DamagedParamId,false);
                animator.SetBool(MeleeAttackParamId,false);
                animator.SetBool(RunParamId,false);
                animator.SetBool(WalkParamId,false);
                animator.SetBool(IdleParamId,true);
                animator.SetBool(JumpParamId,false);
            }
        }
        
        public void SetJumpAnim()
        {
            foreach (var animator in _animators)
            {
                animator.SetBool(DamagedParamId,false);
                animator.SetBool(MeleeAttackParamId,false);
                animator.SetBool(RunParamId,false);
                animator.SetBool(WalkParamId,false);
                animator.SetBool(IdleParamId,false);
                animator.SetBool(JumpParamId,true);
            }
        }
    }
}