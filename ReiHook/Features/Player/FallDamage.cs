using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class FallDamage : MonoBehaviour {
        private void Update() {
            if (Settings.NoFallDamage && LocalPlayer.IsInWorld) {
                LocalPlayer.FpCharacter.allowFallDamage = false;
            }
        }
    }
}
