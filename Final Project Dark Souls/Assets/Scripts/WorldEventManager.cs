using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace DS
{
    public class WorldEventManager : MonoBehaviour
    {
        public FogWall fogwall;
        BossHealthBar bossHealthBar;
        EnemyBossManager boss;
        SoundDesign sound;
        public AudioClip bossFightSong; 

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
            AudioSource.PlayClipAtPoint(bossFightSong, transform.position);
            fogwall.ActivateFogWall();
        }

        public void BosshasBeenDefeated()
        {
            bossHasBeenDefeated = true;
            bossFightIsActive = false;
            fogwall.DeactivateFogWall();
        }
    }
}

