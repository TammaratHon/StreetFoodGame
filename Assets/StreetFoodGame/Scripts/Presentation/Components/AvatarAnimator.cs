using UnityEngine;

namespace StreetFoodGame.Presentation.Components
{
    public class AvatarAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void PlayIdleAnimation()
        {
            if (animator == null) return;
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.IsName("Idle")) return;
            animator.SetTrigger("Idle");
        }

        public void PlayCookingAnimation(int step)
        {
            if (animator == null) return;
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.IsName($"Cooking{step}")) return;
            animator.SetTrigger($"Cooking{step}");
        }
    }
}