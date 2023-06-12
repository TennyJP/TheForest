using ReiHook.Utilities;
using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class Transform : MonoBehaviour {
        private void Update() {
            if (Settings.Transform && LocalPlayer.IsInWorld) {
                if (UnityEngine.Input.GetKey(KeyCode.LeftControl)) { LocalPlayer.Transform.position += 1.25f * Camera.main.transform.forward; }
            }
        }
    }
}
