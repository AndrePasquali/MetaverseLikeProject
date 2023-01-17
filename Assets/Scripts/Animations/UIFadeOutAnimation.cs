using System;
using DG.Tweening;
using UnityEngine;

namespace Genies.Animations
{
    public sealed class UIFadeOutAnimation: UIAnimation
    {
        public override void StartAnimation()
        {
            ChangeState(AnimationState.Running);
        
            Image.DOFade(1, Duration).SetEase(EaseMode).OnComplete(() =>
            {
                ChangeState(AnimationState.Finished);
            });
        }
    }
}