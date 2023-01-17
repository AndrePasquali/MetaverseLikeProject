using DG.Tweening;

namespace Genies.Animations
{
    public sealed class UIFadeInAnimation: UIAnimation
    {
        public override void StartAnimation()
        {
            ChangeState(AnimationState.Running);
        
            Image.DOFade(0, Duration).SetEase(EaseMode).OnComplete(() =>
            {
                ChangeState(AnimationState.Finished);
            });
        }
    }
}