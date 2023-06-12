using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class Energy : MonoBehaviour {
        private void Update() {
            if (Settings.Energy && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.Energy = 100f;
            }
        }
    }
}
