using TheForest.Utils;
using UnityEngine;
namespace ReiHook.Features.Player {
    public class GiveItems : MonoBehaviour {
        public static void GiveAllItems() {
            foreach (TheForest.Items.Item pItems in TheForest.Items.ItemDatabase.Items) { LocalPlayer.Inventory.AddItem(pItems._id, 1000 - LocalPlayer.Inventory.AmountOf(pItems._id, true), true, false, null); }
        }
    }
}
