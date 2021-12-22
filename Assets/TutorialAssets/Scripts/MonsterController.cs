using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace TutorialAssets.Scripts
{
    public abstract class MonsterController : MonoBehaviour
    {
        public enum MonsterState
        {
            Wander = 0,
            Queue = 1,
            Attack = 2,
        }

        [SerializeField] private MonsterState _state;
        [SerializeField] private float _findNewPositionEvery = 2f;
        [SerializeField] private float _maxMoveDistance = 10f;

        private float _wanderTimer = 0;
        private NavMeshAgent _agent;
        
        // Start is called before the first frame update
        void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            
            //add random factor when spawned as to visually stagger finding move positions
            var halfNewPositionEvery = _findNewPositionEvery;
            _findNewPositionEvery += Random.Range(-halfNewPositionEvery, halfNewPositionEvery);
        }

        // Update is called once per frame
        void Update()
        {
            switch (_state)
            {
                case MonsterState.Wander:
                    _wanderTimer += Time.deltaTime;

                    if (_wanderTimer > _findNewPositionEvery)
                    {
                        FindNewWanderPosition();
                        _wanderTimer = 0;
                    }
                    
                    break;
                case MonsterState.Queue:
                    
                    break;
                case MonsterState.Attack:
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void FindNewWanderPosition()
        {
            var newPos = new Vector3(Random.Range(-_maxMoveDistance, _maxMoveDistance), 0, Random.Range(-_maxMoveDistance, _maxMoveDistance));
            _agent.SetDestination(transform.position + newPos);
        }

        public void ChangeState(MonsterState state)
        {
            _agent.enabled = (state == MonsterState.Wander);
            _state = state;
        }
    }
}
