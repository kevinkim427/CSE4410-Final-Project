using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
   public class PassThroughFogWall : Interactable
   {
      WorldEventManager worldEventManager;

      private void Awake()
      {
         worldEventManager = FindFirstObjectByType<WorldEventManager>();
      }

      public override void Interact(PlayerManager playerManager)
      {
         base.Interact(playerManager);
         playerManager.PassThroughFogWallInteraction(transform);
         worldEventManager.ActivateBossFight();
      }
   }
}