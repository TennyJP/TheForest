using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class Thirst : MonoBehaviour {
        private void Update() {
            if (Settings.Thirst && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.Thirst = 0f;
            }
        }
    }
}
