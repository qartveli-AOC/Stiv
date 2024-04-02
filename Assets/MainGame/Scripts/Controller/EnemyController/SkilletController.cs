using System;
using System.Collections;
using System.Collections.Generic;
using Commponents;
using UnityEngine;
using UnityEngine.AI;

namespace Controller
{
    public class SkilletController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Transform _target;
        private Animator _animator;
        public List<Transform> points = new List<Transform>();

        private int _currentIndex = 0;
        private Coroutine _coroutine;

        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Attack = Animator.StringToHash("Attack");
        

        private void Start()
        {
            Initialization();
            ChangeState(PatrolState());
        }

        private void Initialization()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindWithTag("Player").transform;
            _animator = GetComponent<Animator>();
        }

        private void ChangeState(IEnumerator coroutine)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(coroutine);
        }

        private IEnumerator PatrolState()
        {
            while (true)
            {
                if (Vector3.Distance(_target.position, _agent.transform.position) > 15)
                {
                    if (_agent.remainingDistance < 0.1f)
                    {
                        _currentIndex++;
                        if (_currentIndex >= points.Count)
                        {
                            _currentIndex = 0;
                        }
                    }

                    _animator.SetBool(Move, false);
                    yield return new WaitForSeconds(1);
                    _animator.SetBool(Move, true);
                    Debug.Log("Patroling");
                    _agent.SetDestination(points[_currentIndex].position);

                }
                if(Vector3.Distance(_target.position, _agent.transform.position) < 15)
                {
                    ChangeState(MovePlayerState());
                }

                yield return null;
            }
        }

        private IEnumerator MovePlayerState()
        {
            while (true)
            {
                _animator.SetBool(Move, true);
                _agent.SetDestination(_target.position);
                LookAtPlayer();
                
                Debug.Log("Moving Player");

                if (Vector3.Distance(_target.position, _agent.transform.position) > 15f)
                {
                    ChangeState(PatrolState());
                    yield break;
                }

                if (Vector3.Distance(_agent.transform.position, _target.position) <= 2f)
                {
                    ChangeState(AttackState());
                    _currentIndex = 0;
                }

                yield return null;
            }
        }

        private void LookAtPlayer()
        {
            Vector3 directionToTarget = (_target.position - _agent.transform.position).normalized;

                
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));

                
            _agent.transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
        }

        private IEnumerator AttackState()
        {
            _animator.SetBool(Move, false);
            _animator.SetTrigger(Attack);
            Debug.Log("Attack");
            yield return new WaitForSeconds(1);
            _target.GetComponent<HealthComponent>().ModifyHealth(1);
            _animator.SetBool(Move, true);
            ChangeState(MovePlayerState());
        }
    }
}