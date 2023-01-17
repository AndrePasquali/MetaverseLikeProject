using DG.Tweening;
using UnityEngine;

namespace Genies.Animations
{
    public sealed class UIScaleAnimation: UIAnimation
    {
        [SerializeField] private float _maxScale = 0.1F;
        [SerializeField] private float _delay = 1F;
        [SerializeField] private int _vibrato = 0;
        [SerializeField] private float _elasticity = 0;
        [SerializeField] private int _loops = -1;
        
        protected override void StartAnimation()
        {
            ChangeState(AnimationState.Running);
            transform.DOPunchScale(new Vector3(_maxScale, _maxScale, _maxScale), Duration, _vibrato, _elasticity)
                .SetDelay(_delay).SetEase(EaseMode).SetLoops(_loops).OnComplete(() =>
                {
                    ChangeState(AnimationState.Finished);
                });
        }
    }
}