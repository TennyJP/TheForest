using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Miscellaneous {
    public class Fog : MonoBehaviour {
        private void Update() {
            if (Settings.Fog && LocalPlayer.IsInWorld) {
                Scene.Atmosphere.FogStartDistance = 999999999f;
            }
        }
    }
}
