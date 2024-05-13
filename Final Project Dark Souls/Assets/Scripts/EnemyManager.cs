using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DS
{
    public class EnemyManager : CharacterManager
    {
        public State currentState;
        public bool isPerformingAction = false;
        EnemyLocomotionManager enemyLocomotionManager;
        EnemyAnimatorManager enemyAnimationManager;
        EnemyStats enemyStats;
        public CharacterStats currentTarget;

        public NavMeshAgent navmeshAgent;
        public Rigidbody enemyRigidBody;

        public float rotationSpeed = 30;

        [Header("A.I Settings")]
        public float detectionRadius = 20;
        public float maximumDetectionAngle = 50f;
        public float minimumDetectionAngle = -50f;
        public float maximumAttackRange = 1.5f;

        public float currentRecoveryTime = 0;

        private void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
            enemyAnimationManager = GetComponentInChildren<EnemyAnimatorManager>();
            enemyStats = GetComponent<EnemyStats>();
            enemyRigidBody = GetComponent<Rigidbody>();
            navmeshAgent = GetComponentInChildren<NavMeshAgent>();
            navmeshAgent.enabled = false;
        }
        
        private void Start()
        {
            enemyRigidBody.isKinematic = false;
        }
        // Update is called once per frame
        private void Update()
        {
            Debug.Log("Update");
            HandleRecoveryTimer();
        }
        private void FixedUpdate()
        {
            Debug.Log("FixedUpdate");
            HandleStateMachine();
        }
        private void HandleStateMachine()
        {
            Debug.Log("HandleStateMachine");
            if (currentState != null)
            {
                State nextState = currentState.Tick(this, enemyStats, enemyAnimationManager);
                if (nextState != null)
                {
                    SwitchToNextState(nextState);
                }
            }
        }
        private void SwitchToNextState(State state)
        {
            currentState = state;
        }

        private void HandleRecoveryTimer()
        {
            if (currentRecoveryTime > 0)
            {
                Debug.Log("Recovering");
                currentRecoveryTime -= Time.deltaTime;
            }
            if (isPerformingAction)
            {
                if (currentRecoveryTime <= 0)
                {
                    isPerformingAction = false;
                }
            }
        }
    }
}
