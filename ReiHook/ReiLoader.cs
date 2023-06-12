using UnityEngine;
namespace ReiHook {
    public class ReiLoader : MonoBehaviour {
        public static GameObject pLoader;
        public static void ReiAyanami() {
            pLoader = new GameObject();
            pLoader.AddComponent<UI.Menu>();

            pLoader.AddComponent<Features.Player.Transform>();
            pLoader.AddComponent<Features.Player.GodMode>();
            pLoader.AddComponent<Features.Player.Health>();
            pLoader.AddComponent<Features.Player.Armor>();
            pLoader.AddComponent<Features.Player.ColdArmor>();
            pLoader.AddComponent<Features.Player.Stamina>();
            pLoader.AddComponent<Features.Player.Hunger>();
            pLoader.AddComponent<Features.Player.Thirst>();
            pLoader.AddComponent<Features.Player.Energy>();
            pLoader.AddComponent<Features.Player.Oxygen>();
            pLoader.AddComponent<Features.Player.FallDamage>();
            pLoader.AddComponent<Features.Player.JumpInWater>();
            pLoader.AddComponent<Features.Player.GiveItems>();

            pLoader.AddComponent<Features.Visuals.ESP>();

            pLoader.AddComponent<Features.Miscellaneous.CaveLight>();
            pLoader.AddComponent<Features.Miscellaneous.Fog>();
            pLoader.AddComponent<Features.Miscellaneous.Save>();

            DontDestroyOnLoad(pLoader);
        }

        public static void ReiUnload() {
            Destroy(pLoader);
        }
    }
}
