using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public abstract class State : MonoBehaviour
    {
        public abstract State Tick(EnemyManager enemyManger, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager);
    }
}

