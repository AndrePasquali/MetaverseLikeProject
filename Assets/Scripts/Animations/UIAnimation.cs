using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Genies.Animations
{
    public abstract class UIAnimation: MonoBehaviour
    {
        public float Duration = 2.0F;

        public Ease EaseMode = Ease.Linear;

        public LoopType LoopType = LoopType.Incremental;

        [SerializeField] private bool _autoRun;

        public Image Image => _image ?? (_image = GetComponent<Image>());

        private Image _image;
        

        public enum AnimationState
        {
            Stopped,
            Running,
            Finished
        }

        public AnimationState CurrentAnimationState = AnimationState.Stopped;
        
        private void Start()
        {
            if(_autoRun) StartAnimation();
        }

        protected abstract void StartAnimation();

        protected void ChangeState(AnimationState newState) => CurrentAnimationState = newState;
    }
}