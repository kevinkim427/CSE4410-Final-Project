using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class WorldEventManager : MonoBehaviour
    {
        public FogWall fogwall;
        BossHealthBar bossHealthBar;
        EnemyBossManager boss;
        SoundDesign sound;

        public bool bossFightIsActive;
        public bool bossHasBeenAwakened;
        public bool bossHasBeenDefeated;

        private void Awake()
        {
            bossHealthBar = FindFirstObjectByType<BossHealthBar>();
        }

        public void ActivateBossFight()
        {
            bossFightIsActive = true;
            bossHasBeenAwakened = true;
            bossHealthBar.SetHealthBarToActive();
            fogwall.ActivateFogWall();
//            sound.isBossFightScene = true;
        }

        public void BosshasBeenDefeated()
        {
            bossHasBeenDefeated = true;
            bossFightIsActive = false;
            fogwall.DeactivateFogWall();
        }
    }
}

