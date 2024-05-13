using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class EventColliderBeginBossFight : MonoBehaviour
    {
        WorldEventManager worldEventManager;

        private void Awake()
        {
            worldEventManager = FindFirstObjectByType<WorldEventManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                worldEventManager.ActivateBossFight();
            }
        }
    }
}

