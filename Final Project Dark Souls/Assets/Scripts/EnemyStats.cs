using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class EnemyStats : CharacterStats
    {
        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
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
            animator.Play("Damage");

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Dead");
                isDead = true;
                // Handle Enemy Death;
            }
        }
    }
}