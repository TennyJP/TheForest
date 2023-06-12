using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class Health : MonoBehaviour {
        private void Update() {
            if (Settings.Health && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.Health = 100f;
            }
        }
    }
}
