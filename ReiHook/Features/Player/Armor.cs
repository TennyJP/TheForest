using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class Armor : MonoBehaviour {
        private void Update() {
            if (Settings.Armor && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.Armor = 100;
            }
        }
    }
}
