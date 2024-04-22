using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class PlayerAttacker : MonoBehaviour
    {
        PlayerStats playerStats;
        AnimatorHandler animatorHandler;
        WeaponSlotManager weaponSlotManager;

        private void Awake()
        {
            playerStats = GetComponent<PlayerStats>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        public void HandleLightAttack(WeaponItem weapon)
        {
            if(playerStats.currentStamina <= 0)
                return;
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.Light_Attack, true);
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            if(playerStats.currentStamina <= 0)
                return;
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.Heavy_Attack, true);
        }
    }
}