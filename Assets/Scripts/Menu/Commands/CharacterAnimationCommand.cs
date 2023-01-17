using UnityEngine;

namespace Genies.Menu
{
    public class CharacterAnimationCommand: IMenuCommand
    {
        private Animator _characterAnimator;
        
        private string _animationName;

        public CharacterAnimationCommand(Animator animator, string animationName)
        {
            _characterAnimator = animator;
            _animationName = animationName;
        }
        
        public void Execute()
        {
            _characterAnimator.SetTrigger(_animationName);
        }
    }
}