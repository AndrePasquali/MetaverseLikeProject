using UnityEngine;

namespace Genies.Menu
{
    public class CharacterAnimationCommand: IMenuCommand
    {
        private Animator _characterAnimator;

        private string _animationClipName;

        public int AnimationIndex
        {
            get => _animationIndex;
            private set
            {
                switch (value)
                {
                    case 0: _animationClipName = "Waving"; break;
                    case 1: _animationClipName = "Excited"; break;
                    case 2: _animationClipName = "Wave"; break;
                    case 3: _animationClipName = "Dancing"; break;
                }
                _animationIndex = value;
            }
        }
        private int _animationIndex { get; set; }

        public CharacterAnimationCommand(Animator animator, int animationIndex)
        {
            _characterAnimator = animator;
            AnimationIndex = animationIndex;
        }
        
        public void Execute()
        {
            _characterAnimator.SetTrigger(_animationClipName);
        }
    }
}