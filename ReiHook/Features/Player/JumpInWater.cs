using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class JumpInWater : MonoBehaviour {
        private void Update() {
            if (Settings.JumpInWater && LocalPlayer.IsInWorld) {
                LocalPlayer.FpCharacter.allowWaterJump = true;
            }
        }
    }
}
