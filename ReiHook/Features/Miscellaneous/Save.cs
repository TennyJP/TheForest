using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Miscellaneous {
    public class Save : MonoBehaviour {
        public static void SaveGame() {
            LocalPlayer.Stats.JustSave();
        }
    }
}
