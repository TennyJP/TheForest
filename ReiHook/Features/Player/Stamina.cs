using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class Stamina : MonoBehaviour {
        private void Update() {
            if (Settings.Stamina && LocalPlayer.IsInWorld) {
                LocalPlayer.Stats.Stamina = 100f;
            }
        }
    }
}
