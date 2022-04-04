using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class WaypointPatrol : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        public Transform[] waypoints;
        private bool _haveTargetPlayer;
        private int m_CurrentWaypointIndex;

        private void Start ()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.SetDestination (waypoints[0].position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.TryGetComponent(out MovingSystem player))
                {
                    _haveTargetPlayer = true;
                    _navMeshAgent.SetDestination(player.transform.position);
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            var collisionObject = other.gameObject;
            if (collisionObject.CompareTag("Player"))
            {
                if (collisionObject.TryGetComponent(out MovingSystem player))
                {
                    _haveTargetPlayer = false;
                    _navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                }
            }
        }

        private void Update ()
        {
            if (_haveTargetPlayer) return;
            if(_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                _navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
            }
        }
    }
}
