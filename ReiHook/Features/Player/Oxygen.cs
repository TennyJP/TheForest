using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class Oxygen : MonoBehaviour {
        private void Update() {
            if (Settings.Oxygen && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.AirBreathing.CurrentLungAir = 9000f;
                LocalPlayer.Stats.AirBreathing.TakingDamage = false;
            }
        }
    }
}
