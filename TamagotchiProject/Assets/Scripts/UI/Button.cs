using Controllers;
using UnityEngine;

namespace UI
{
    public class Button : MonoBehaviour
    {
        private Animator buttonAnimator;

        private void Start()
        {
            buttonAnimator = GetComponent<Animator>();
        }

        public void PlayButtonAnimation(string animationName)
        {
            if (!buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("HudButtonDoubleTempo"))
            {
                buttonAnimator.Play(animationName);
            }
        }

        public void ButtonDoubleTempoAnimation()
        {
            buttonAnimator.Play(GameController.DoubleTempo ? "HudButtonDoubleTempo" : "HudButtonEnter");
        }
    }
}