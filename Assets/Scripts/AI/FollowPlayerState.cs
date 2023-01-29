using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Genies.AI
{
    public class FollowPlayerState: IAIState
    {
        private AIStateMachine _stateMachine;
        private Transform _player;
        private NavMeshAgent _agent;
        private Animator _animator;
        private List<string> _animation = new List<string>{"Wave", "Waving", "Excited", "Dancing", "Jumping", "HipHop"};
        private float _timerCounter;

        public FollowPlayerState(AIStateMachine stateMachine, Transform player, NavMeshAgent agent, Animator animator)
        {
            _stateMachine = stateMachine;
            _player = player;
            _agent = agent;
            _animator = animator;
        }

        public void UpdateState()
        {
           _agent.destination = _player.position;

            if (ReachedPlayer())
            {
                _agent.isStopped = true;

                if(!_animator.IsInTransition(0))
                _animator.SetTrigger(PickAnimation());

                _timerCounter += Time.deltaTime;
                
                if(_timerCounter < 20F) return;

                _timerCounter = 0;
                
                _agent.isStopped = false;

                _stateMachine.ChangeState(_stateMachine.WalkAroundState);
            }
        }

        public bool ReachedPlayer()
        {
            var distanceToPlayer = Vector3.Distance(_agent.transform.position, _player.position) <= 3.0F;

            return distanceToPlayer;
        }

        private string PickAnimation() => _animation[Random.Range(0, _animation.Count)];
    }
}