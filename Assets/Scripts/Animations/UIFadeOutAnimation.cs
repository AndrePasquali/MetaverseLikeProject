using System;
using DG.Tweening;

namespace Genies.Animations
{
    public sealed class UIFadeOutAnimation: UIAnimation
    {
        private void Awake() => Image.DOFade(0, 0);

        protected override void StartAnimation()
        {
            ChangeState(AnimationState.Running);
        
            Image.DOFade(1, Duration).SetEase(EaseMode).OnComplete(() =>
            {
                ChangeState(AnimationState.Finished);
            });
        }
    }
}