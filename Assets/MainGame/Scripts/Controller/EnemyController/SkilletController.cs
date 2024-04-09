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
        [HideInInspector]
        public NavMeshAgent _agent;
        private Transform _target;
        private Animator _animator;
        public List<Transform> points = new List<Transform>();

        private int _currentIndex = 0;
        private Coroutine _coroutine;

        private static readonly int Move = Animator.StringToHash("Move");


        private void Start()
        {
            Initialization();
            ChangeState(PatrolState());
        }

        private void Initialization()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindWithTag("Player").transform;
            _animator = GetComponentInChildren<Animator>();
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
            while (_agent != null && _agent.isActiveAndEnabled)
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
            while (_agent != null && _agent.isActiveAndEnabled)
            {
                _animator.SetBool(Move, true);
                if (_agent != null)
                {
                    if (_target != null)
                    {
                        _agent.SetDestination(_target.position);  
                    }
                    
                    
                }
                
               
                
                
                Debug.Log("Moving Player");

                if (Vector3.Distance(_target.position, _agent.transform.position) > 15f)
                {
                    ChangeState(PatrolState());
                    yield break;
                }

                if (Vector3.Distance(_agent.transform.position, _target.position) <= 1f)
                {
                    _currentIndex = 0;
                    yield break;
                }

                yield return null;
            }
        }

      

       
        
    }
}