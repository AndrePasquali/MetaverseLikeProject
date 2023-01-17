using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
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

        [SerializeField] protected UnityEvent OnAnimationFinishedEvent;
        

        public enum AnimationState
        {
            Stopped,
            Running,
            Finished
        }

        public AnimationState CurrentAnimationState
        {
            get => _currentAnimationState;
            set
            {
                _currentAnimationState = value;

                switch (value)
                {
                    case AnimationState.Finished: OnAnimationFinished(); break;
                }
            }
        }
        private AnimationState _currentAnimationState;
        private void Start()
        {
            if(_autoRun) StartAnimation();
        }

        public abstract void StartAnimation();

        protected virtual void OnAnimationFinished()
        {
            OnAnimationFinishedEvent?.Invoke();
        }

        protected void ChangeState(AnimationState newState) => CurrentAnimationState = newState;
    }
}