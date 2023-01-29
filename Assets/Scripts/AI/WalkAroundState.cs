using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Genies.AI
{
    public class WalkAroundState : MonoBehaviour, IAIState
    {
        private AIStateMachine _stateMachine;
        private NavMeshAgent _agent;
        private Transform[] _wayPoints;
        private Transform _currentDestination;
        private float _timeCounter;

        public WalkAroundState(AIStateMachine stateMachine, NavMeshAgent agent, Transform[] wayPoints)
        {
            _stateMachine = stateMachine;
            _agent = agent;
            _wayPoints = wayPoints;
            _currentDestination = wayPoints[Random.Range(0, _wayPoints.Length - 1)];
        }

        public void UpdateState()
        {
            _agent.SetDestination(_currentDestination.position);

            if (HasReachedDestination())
            {
                _agent.isStopped = true;
                
                _timeCounter += Time.deltaTime;
                
                if(_timeCounter <= 20F) return;

                _timeCounter = 0;

                _agent.isStopped = false;
                
                _stateMachine.ChangeState(_stateMachine.FollowPlayerState);
            }
        }

        private bool HasReachedDestination()
        {
            var isNear = Vector3.Distance(_agent.transform.position, _currentDestination.position) <= 3F;

            return isNear;
        }
    }
}