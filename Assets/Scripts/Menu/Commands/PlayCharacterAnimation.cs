using UnityEngine;

namespace Genies.Menu
{
    public class PlayCharacterAnimation: IMenuCommand
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
                    case 0: _animationClipName = "Jump"; break;
                    case 1: _animationClipName = "Pickup"; break;
                    case 2: _animationClipName = "Wave"; break;
                    case 3: _animationClipName = "Land"; break;
                }
                _animationIndex = value;
            }
        }
        private int _animationIndex { get; set; }

        public PlayCharacterAnimation(Animator animator, int animationIndex)
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