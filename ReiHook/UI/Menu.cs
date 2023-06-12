using UnityEngine;
using ReiHook.Utilities;
using TheForest.Utils;
using System;
using TheForest.Items.Inventory;
using System.Reflection;
using System.IO;
namespace ReiHook.UI {
    public class Menu : MonoBehaviour {
        private Rect MainWindow;
        private Rect PlayerWindow;
        private Rect VisualWindow;
        private Rect MiscellaneousWindow;
        private Rect GiveItemWindow;
        private Rect SpawnEnemyWindow;

        Vector2 ScrollPosition;
        GUIStyle WatermarkStyle = new GUIStyle();
        GUIStyle LabelStyle = new GUIStyle();

        private bool bGUI = false;
        private bool bPlayerWindow = false;
        private bool bVisualWindow = false;
        private bool bMiscellaneousWindow = false;
        private bool bGiveItemWindow = false;
        private bool bSpawnEnemyWindow = false;
        private void Start() {
            MainWindow = new Rect(20f, 60f, 280f, 150f);
            WatermarkStyle.normal.textColor = Color.yellow; LabelStyle.normal.textColor = Color.white;
        }

        private void Update() {
            ToggleMenu();
            if(UnityEngine.Input.GetKeyDown(KeyCode.Delete)) { ReiLoader.ReiUnload(); }
        }

        private void ToggleMenu() {
            if (UnityEngine.Input.GetKeyDown(KeyCode.F4)) {
                bGUI = !bGUI;
                if (bGUI) {
                    LocalPlayer.FpCharacter.LockView();
                    LocalPlayer.Inventory.CurrentView = PlayerInventory.PlayerViews.Loading;
                    Cursor.visible = true;
                }
                else {
                    Cursor.visible = false;
                    LocalPlayer.Inventory.CurrentView = PlayerInventory.PlayerViews.World;
                    LocalPlayer.FpCharacter.UnLockView();
                }
            }
        }

        private void OnGUI() {
            GUI.Label(new Rect(20, 20, 200, 60), "UnKnoWnCheaTs.me | Tenny", WatermarkStyle); GUI.Label(new Rect(20, 40, 200, 60), "ReiHook for The Forest v1.0", WatermarkStyle);
            if (!bGUI) return;
            GUI.backgroundColor = Color.grey; GUI.contentColor = Color.white;
            MainWindow = GUILayout.Window(0, MainWindow, new GUI.WindowFunction(UI), "Menu", new GUILayoutOption[0]);
            if (bPlayerWindow) { PlayerWindow = GUILayout.Window(1, PlayerWindow, new GUI.WindowFunction(UI), "Player", new GUILayoutOption[0]); }
            if (bVisualWindow) { VisualWindow = GUILayout.Window(2, VisualWindow, new GUI.WindowFunction(UI), "Visual", new GUILayoutOption[0]); }
            if (bMiscellaneousWindow) { MiscellaneousWindow = GUILayout.Window(3, MiscellaneousWindow, new GUI.WindowFunction(UI), "Miscellaneous", new GUILayoutOption[0]); }
            if (bGiveItemWindow) { GiveItemWindow = GUILayout.Window(4, GiveItemWindow, new GUI.WindowFunction(UI), "Give Items", new GUILayoutOption[0]); }
            if (bSpawnEnemyWindow) { SpawnEnemyWindow = GUILayout.Window(5, SpawnEnemyWindow, new GUI.WindowFunction(UI), "Spawn Enemies", new GUILayoutOption[0]); }
        }

        private void UI(int pID) {
            GUI.backgroundColor = Color.grey; GUI.contentColor = Color.white;
            switch (pID) {
                case 0:
                    GUILayout.Label("Press F4 for Menu", LabelStyle, new GUILayoutOption[0]);
                    GUILayout.Label("Delete to Unhook the Cheat", LabelStyle, new GUILayoutOption[0]);
                    if (GUILayout.Button("Player", new GUILayoutOption[0])) { bPlayerWindow = !bPlayerWindow; }
                    if (GUILayout.Button("Visual", new GUILayoutOption[0])) { bVisualWindow = !bVisualWindow; }
                    if (GUILayout.Button("Miscellaneous", new GUILayoutOption[0])) { bMiscellaneousWindow = !bMiscellaneousWindow; }
                    if (GUILayout.Button("Give Items", new GUILayoutOption[0])) { bGiveItemWindow = !bGiveItemWindow; }
                    if (GUILayout.Button("Spawn Enemies", new GUILayoutOption[0])) { bSpawnEnemyWindow = !bSpawnEnemyWindow; }
                    break;
                case 1:
                    Settings.Transform = GUILayout.Toggle(Settings.Transform, "Transform Player [LeftControl]", new GUILayoutOption[0]);
                    Settings.GodMode = GUILayout.Toggle(Settings.GodMode, "God Mode", new GUILayoutOption[0]);
                    Settings.Health = GUILayout.Toggle(Settings.Health, "Unlimited Health", new GUILayoutOption[0]);
                    Settings.Armor = GUILayout.Toggle(Settings.Armor, "Unlimited Armor", new GUILayoutOption[0]);
                    Settings.ColdArmor = GUILayout.Toggle(Settings.ColdArmor, "Unlimited Cold Armor", new GUILayoutOption[0]);
                    Settings.Stamina = GUILayout.Toggle(Settings.Stamina, "Unlimited Stamina", new GUILayoutOption[0]);
                    Settings.Hunger = GUILayout.Toggle(Settings.Hunger, "No Hunger", new GUILayoutOption[0]);
                    Settings.Thirst = GUILayout.Toggle(Settings.Thirst, "No Thirst", new GUILayoutOption[0]);
                    Settings.Energy = GUILayout.Toggle(Settings.Energy, "Unlimited Energy", new GUILayoutOption[0]);
                    Settings.Oxygen = GUILayout.Toggle(Settings.Oxygen, "Unlimited Oxygen", new GUILayoutOption[0]);
                    Settings.NoFallDamage = GUILayout.Toggle(Settings.NoFallDamage, "No Fall Damage", new GUILayoutOption[0]);
                    Settings.JumpInWater = GUILayout.Toggle(Settings.JumpInWater, "Allow Jump in Water", new GUILayoutOption[0]);
                    if (GUILayout.Button("Give All Items", new GUILayoutOption[0])) { Features.Player.GiveItems.GiveAllItems(); }
                    break;
                case 2:
                    Settings.ESP = GUILayout.Toggle(Settings.ESP, "Enable ESP", new GUILayoutOption[0]);
                    Settings.Skeleton = GUILayout.Toggle(Settings.Skeleton, "Cannibal Skeleton", new GUILayoutOption[0]);
                    Settings.Cannibal = GUILayout.Toggle(Settings.Cannibal, "Cannibal" + "[" + Mathf.Round(Settings.fCannibal) + "m]", new GUILayoutOption[0]);
                    Settings.fCannibal = Mathf.Round(GUILayout.HorizontalSlider(Settings.fCannibal, 1f, 1000f, new GUILayoutOption[0]) * 1000f) / 1000f;
                    Settings.Animals = GUILayout.Toggle(Settings.Animals, "Animals" + "[" + Mathf.Round(Settings.fAnimals) + "m]", new GUILayoutOption[0]);
                    Settings.fAnimals = Mathf.Round(GUILayout.HorizontalSlider(Settings.fAnimals, 1f, 1000f, new GUILayoutOption[0]) * 1000f) / 1000f;
                    Settings.Plane = GUILayout.Toggle(Settings.Plane, "Plane Crash Site" + "[" + Mathf.Round(Settings.fPlane) + "m]", new GUILayoutOption[0]);
                    Settings.fPlane = Mathf.Round(GUILayout.HorizontalSlider(Settings.fPlane, 1f, 1000f, new GUILayoutOption[0]) * 1000f) / 1000f;
                    Settings.Yacht = GUILayout.Toggle(Settings.Yacht, "Yacht" + "[" + Mathf.Round(Settings.fYacht) + "m]", new GUILayoutOption[0]);
                    Settings.fYacht = Mathf.Round(GUILayout.HorizontalSlider(Settings.fYacht, 1f, 1000f, new GUILayoutOption[0]) * 1000f) / 1000f;
                    Settings.Cave = GUILayout.Toggle(Settings.Cave, "Cave" + "[" + Mathf.Round(Settings.fCave) + "m]", new GUILayoutOption[0]);
                    Settings.fCave = Mathf.Round(GUILayout.HorizontalSlider(Settings.fCave, 1f, 1000f, new GUILayoutOption[0]) * 1000f) / 1000f;
                    Settings.Sinkhole = GUILayout.Toggle(Settings.Sinkhole, "Sinkhole" + "[" + Mathf.Round(Settings.fSinkhole) + "m]", new GUILayoutOption[0]);
                    Settings.fSinkhole = Mathf.Round(GUILayout.HorizontalSlider(Settings.fSinkhole, 1f, 1000f, new GUILayoutOption[0]) * 1000f) / 1000f;
                    break;
                case 3:
                    Settings.Fullbright = GUILayout.Toggle(Settings.Fullbright, "Fullbright", new GUILayoutOption[0]);
                    Settings.Fog = GUILayout.Toggle(Settings.Fog, "No Fog", new GUILayoutOption[0]);
                    if (GUILayout.Button("Save Game", new GUILayoutOption[0])) { Features.Miscellaneous.Save.SaveGame(); }
                    break;
                case 4:
                    ScrollPosition = GUILayout.BeginScrollView(ScrollPosition, GUILayout.Width(350), GUILayout.Height(500));
                    foreach (int i in Enum.GetValues(typeof(ItemIDs)))
                    {
                        if (GUILayout.Button(Enum.GetName(typeof(ItemIDs), i), new GUILayoutOption[0])) { LocalPlayer.Inventory.AddItem(i, 1, false, false, null); }
                    }
                    GUILayout.EndScrollView();
                    break;
                case 5:
                    if (GUILayout.Button("Skinned Mask Male", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.skinMaskMale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Regular Male", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.regularMale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Regular Female", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.regularFemale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Skinny Male", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.skinnyMale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Skinny Female", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.skinnyFemale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Pale Male", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.paleMale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Pale Female", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.paleFemale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Skinny Pale Male", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.skinnyMalePale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Skinny Pale Female", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.skinnyFemalePale, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Regular Male Fireman", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.regularMaleFireman, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Regular Male Leader", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.regularMaleLeader, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Armsy", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.creepyArmsy, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Mutant Baby", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.creepyBaby, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Cowman", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.creepyFat, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Virginia", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.creepySpiderLady, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Blue Armsy", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.blueCreepyArmsy, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    if (GUILayout.Button("Blue Virginia", new GUILayoutOption[0])) { Features.Miscellaneous.Spawn.SpawnEnemy(EnemyType.blueCreepySpiderLady, 1, LocalPlayer.Transform.position, Vector3.zero); }
                    break;
                default:
                    break;
            }
            GUI.DragWindow();
        }
    }
}
