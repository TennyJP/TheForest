using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class GodMode : MonoBehaviour {
        private void Update() {
            if (Settings.GodMode && LocalPlayer.IsInWorld) {
                LocalPlayer.FpCharacter.hitByEnemy = false;
                LocalPlayer.Stats.Health = 100f;
                LocalPlayer.FpCharacter.allowFallDamage = false;
            }
        }
    }
}
