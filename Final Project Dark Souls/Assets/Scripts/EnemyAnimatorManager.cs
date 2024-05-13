using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class EnemyAnimatorManager : AnimatorManager
    {
        EnemyManager enemyManager;

        // Start is called before the first frame update
        private void Awake()
        {
            anim = GetComponent<Animator>();
            enemyManager = GetComponentInParent<EnemyManager>();
        }

        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;
            enemyManager.enemyRigidBody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            enemyManager.enemyRigidBody.velocity = velocity;
        }
    }
}
