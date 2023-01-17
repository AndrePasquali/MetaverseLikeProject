using UnityEngine;
using UnityEngine.AI;

namespace Genies.AI
{ 
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIStateMachine : MonoBehaviour
    {
        public Transform Player => _player ?? (_player = GameObject.FindWithTag("Player").transform);
        private Transform _player;
        public NavMeshAgent Agent => _agent ?? (_agent = GetComponent<NavMeshAgent>());
        private NavMeshAgent _agent;

        [SerializeField] private Animator _animator;

        public IAIState CurrentState;
        [HideInInspector] public FollowPlayerState FollowPlayerState;
        [HideInInspector] public WalkAroundState WalkAroundState;

        public Transform[] Waypoints => _waypoints ??
                                        (_waypoints = GameObject.FindWithTag("Respawn")
                                            .GetComponentsInChildren<Transform>());
        private Transform[] _waypoints;

        private void Start()
        {
            FollowPlayerState = new FollowPlayerState(this, Player, Agent, _animator);
            WalkAroundState = new WalkAroundState(this, Agent, Waypoints);
            CurrentState = FollowPlayerState;
        }

        private void Update()
        {
            CurrentState.Update();
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = Agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            
            _animator.SetFloat("MoveSpeed", localVelocity.z);
        }

        public void ChangeState(IAIState newState)
        {
            CurrentState = newState;
        }

        public void OnDestroy()
        {
            Agent.gameObject.SetActive(false);
        }
    }
    
}