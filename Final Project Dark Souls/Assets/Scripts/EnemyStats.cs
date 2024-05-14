using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DS
{
    public class EnemyStats : CharacterStats
    {
        EnemyAnimatorManager animatorHandler;
        EnemyBossManager enemyBossManager;
        public BossHealthBar healthBar;
        public AudioClip hitSound;
        public AudioClip deathSound;

        public bool isBoss;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<EnemyAnimatorManager>();
            enemyBossManager = GetComponent<EnemyBossManager>();
            healthBar = GetComponent<BossHealthBar>();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        void Start()
        {
            if(!isBoss)
            {
                maxHealth = SetMaxHealthFromHealthLevel();
            }
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            if(isDead)
                return;
            currentHealth = currentHealth - damage;
            animatorHandler.PlayTargetAnimation("Damage", true);
            AudioSource.PlayClipAtPoint(hitSound, transform.position);

            if(isBoss) 
            {
                enemyBossManager.UpdateBossHealthBar(currentHealth);
            }

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                animatorHandler.PlayTargetAnimation("Dead", true);
                isDead = true;
                // Handle Enemy Death;
                Destroy(this.gameObject);
            }

            if(isBoss && currentHealth <= 0)
            {
                currentHealth = 0;
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                animatorHandler.PlayTargetAnimation("Dead", true);
                isDead = true;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}