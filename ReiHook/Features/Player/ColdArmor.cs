using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class ColdArmor : MonoBehaviour {
        private void Update() {
            if (Settings.ColdArmor && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.ColdArmor = 100f;
            }
        }
    }
}
