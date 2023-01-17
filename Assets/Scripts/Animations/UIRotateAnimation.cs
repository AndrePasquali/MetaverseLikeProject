using DG.Tweening;
using UnityEngine;

namespace Genies.Animations
{
    public sealed class UIRotateAnimation: UIAnimation
    {
        public override void StartAnimation()
        {
            ChangeState(AnimationState.Running);
            
            Image.transform.DORotate(new Vector3(0, 0, -90), Duration).OnComplete( 
                () => ChangeState(AnimationState.Finished));
        }
        
    }
}