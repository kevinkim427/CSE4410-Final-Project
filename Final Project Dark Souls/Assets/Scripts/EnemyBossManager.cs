using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class EnemyBossManager : MonoBehaviour
    {
        public string bossName;
        
        BossHealthBar bossHealthBar;
        EnemyStats bossStats;

        private void Awake()
        {
            bossHealthBar = FindAnyObjectByType<BossHealthBar>();
            bossStats = GetComponent<EnemyStats>();
        }

        private void Start()
        {
            bossHealthBar.setBossName(bossName);
            bossHealthBar.SetBossMaxHealth(bossStats.maxHealth);
        }

        public void UpdateBossHealthBar(int currentHealth)
        {
            Debug.Log("UpdateBossHealthBar");
            bossHealthBar.SetBossCurrentHealth(currentHealth);
        }

    }
}

