using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Miscellaneous {
    public class CaveLight : MonoBehaviour {
        private void Update() {
            if (Settings.Fullbright && LocalPlayer.IsInCaves) {
                Scene.Atmosphere.CaveAmbientIntensity = 0f;
            }
        }
    }
}
