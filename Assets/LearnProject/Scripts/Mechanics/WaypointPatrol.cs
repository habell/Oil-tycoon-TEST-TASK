using Learning.Scripts.Enemyes.Turret;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class WaypointPatrol : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent _navMeshAgent;
        
        public Transform[] Waypoints { get; private set; }

        [SerializeField]
        private float _howSecondNeedToRemoveTarget = 2f;

        private float _defaultUPPT;
        private bool _haveTargetPlayer;
        private float _playerTargetTimer = -1;
        private GameObject _targetPlayer;
        private float _updatePlayerPositionTimer = 1f;
        private int m_CurrentWaypointIndex;

        private void Update()
        {
            if(Waypoints == null || Waypoints.Length < 1) return;
            
            if (_haveTargetPlayer)
            {
                if (_updatePlayerPositionTimer > 0)
                {
                    _updatePlayerPositionTimer -= Time.deltaTime;
                }
                else
                {
                    _updatePlayerPositionTimer = _defaultUPPT;
                    _navMeshAgent.SetDestination(_targetPlayer.transform.position);
                }

                if (_playerTargetTimer == -1)
                    return;
                if (_playerTargetTimer > 0)
                    _playerTargetTimer -= Time.deltaTime;
                if (_playerTargetTimer <= 0)
                {
                    _haveTargetPlayer = false;
                    _navMeshAgent.SetDestination(Waypoints[m_CurrentWaypointIndex].position);
                    _targetPlayer = null;
                    if (TryGetComponent(out TurretAttack turretAttack)) turretAttack.SetAttackStatus(false);
                }

                return;
            }

            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % Waypoints.Length;
                _navMeshAgent.SetDestination(Waypoints[m_CurrentWaypointIndex].position);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                if (other.TryGetComponent(out MovingSystem player))
                {
                    _playerTargetTimer = -1;
                    _haveTargetPlayer = true;
                    _targetPlayer = player.gameObject;
                    _navMeshAgent.SetDestination(_targetPlayer.transform.position);
                    if (TryGetComponent(out TurretAttack turretAttack)) turretAttack.SetAttackStatus(true);
                }
        }

        private void OnTriggerExit(Collider other)
        {
            var collisionObject = other.gameObject;
            if (collisionObject.CompareTag("Player"))
                if (collisionObject.TryGetComponent(out MovingSystem player))
                    _playerTargetTimer = _howSecondNeedToRemoveTarget;
        }

        public void SetWaypoints(Transform[] waypoints)
        {
            Waypoints = waypoints;
            _defaultUPPT = _updatePlayerPositionTimer;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.SetDestination(Waypoints[0].position);
        }
    }
}