using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;

namespace ReiHook.Features.Player {
    public class Hunger : MonoBehaviour {
        private void Update() {
            if (Settings.Hunger && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.Fullness = 100f;
                LocalPlayer.Stats.StarvationCurrentDuration = 0f;
            }
        }
    }
}
