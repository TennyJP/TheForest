using UnityEngine;
using ReiHook.Utilities;
using TheForest.Utils;
using PathologicalGames;
using System.Text.RegularExpressions;

namespace ReiHook.Features.Visuals {
    public class ESP : MonoBehaviour {
        private static Camera ReiCamera;
        private void Update() {
            ReiCamera = Camera.main;
        }

        void OnGUI() {
            if (Event.current.type != EventType.Repaint) return;
            if (Settings.ESP && LocalPlayer.IsInWorld) {
                if (Settings.Cannibal || Settings.Skeleton) {
                    if (LocalPlayer.IsInOutsideWorld) {
                        foreach (GameObject Cannibals in Scene.MutantControler.activeWorldCannibals) {
                            if (!Cannibals) continue;
                            mutantScriptSetup Mutants = Cannibals.GetComponentInChildren<mutantScriptSetup>();
                            enemyType MutantType = Cannibals.GetComponentInChildren<enemyType>();
                            Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Mutants.transform.position);
                            EnemyHealth enemyHealth = Mutants.GetComponent<EnemyHealth>();
                            int CurrentHealth = enemyHealth.Health;
                            float ReiDistance = Vector3.Distance(LocalPlayer.Transform.position, Mutants.transform.position);
                            if (Render.IsOnScreen(WorldToScreen)) {
                                if (ReiDistance < Settings.fCannibal) {
                                    if (Settings.Skeleton) { Skeleton(Mutants.animator); }
                                    if (Settings.Cannibal) {
                                        if (MutantType.Type == EnemyType.regularMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Male", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.regularMaleFireman) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Fire", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.regularMaleLeader) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Male Leader", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.paleMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Male", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.regularFemale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Female", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Skinny Male", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyFemale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Skinny Female", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepyArmsy) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Armsy", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepySpiderLady) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Virginia", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepyBaby) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Mutant Baby", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyMalePale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Skinny Male", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepyFat) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Cowman", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyFemalePale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Skinny Female", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.paleFemale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Female", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.blueCreepyArmsy) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Blue Armsy", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.blueCreepySpiderLady) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Blue Virginia", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinMaskMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Masked Male", Color.red, true, 12, FontStyle.Normal); }
                                        Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), CurrentHealth + " HP", Color.white, true, 12, FontStyle.Normal);
                                        Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 24), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                                    }
                                }
                            }
                        }
                    }

                    if (LocalPlayer.IsInCaves) {
                        foreach (GameObject Cannibals in Scene.MutantControler.activeCaveCannibals) {
                            if (!Cannibals) continue;
                            mutantScriptSetup Mutants = Cannibals.GetComponentInChildren<mutantScriptSetup>();
                            enemyType MutantType = Cannibals.GetComponentInChildren<enemyType>();
                            Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Mutants.transform.position);
                            EnemyHealth enemyHealth = Mutants.GetComponent<EnemyHealth>();
                            int CurrentHealth = enemyHealth.Health;
                            float ReiDistance = Vector3.Distance(LocalPlayer.Transform.position, Mutants.transform.position);
                            if (Render.IsOnScreen(WorldToScreen)) {
                                if (ReiDistance < Settings.fCannibal) {
                                    if (Settings.Skeleton) { Skeleton(Mutants.animator); }
                                    if (Settings.Cannibal) {
                                        if (MutantType.Type == EnemyType.regularMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Male Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.regularMaleFireman) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Fire Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.regularMaleLeader) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Male Cannibal Leader", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.paleMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Male Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.regularFemale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Female Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Skinny Male Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyFemale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Skinny Female Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepyArmsy) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Armsy", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepySpiderLady) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Virginia", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepyBaby) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Mutant Baby", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyMalePale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Skinny Male Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.creepyFat) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Cowman", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinnyFemalePale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Skinny Female Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.paleFemale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Pale Female Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.blueCreepyArmsy) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Blue Armsy", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.blueCreepySpiderLady) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Blue Virginia", Color.red, true, 12, FontStyle.Normal); }
                                        if (MutantType.Type == EnemyType.skinMaskMale) { Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Masked Male Cannibal", Color.red, true, 12, FontStyle.Normal); }
                                        Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), CurrentHealth + " HP", Color.white, true, 12, FontStyle.Normal);
                                        Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 24), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                                    }
                                }
                            }
                        }
                    }
                }

                if (Settings.Animals) {
                    if (LocalPlayer.IsInOutsideWorld) {
                        foreach (Transform Animals in PoolManager.Pools["creatures"]) {
                            if (!Animals) continue;
                            Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Animals.transform.position);
                            animalHealth animalHealth = Animals.GetComponent<animalHealth>();
                            int CurrentHealth = animalHealth.Health;
                            float ReiDistance = Vector3.Distance(LocalPlayer.Transform.position, Animals.transform.position);
                            if (Render.IsOnScreen(WorldToScreen)) {
                                if (ReiDistance < Settings.fAnimals) {
                                    Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), Replace(Animals.name), Color.green, true, 12, FontStyle.Normal);
                                    Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), CurrentHealth + " HP", Color.white, true, 12, FontStyle.Normal);
                                    Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 24), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                                }
                            }
                        }
                    }
                }

                if (Settings.Plane) {
                    Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Scene.SceneTracker.planeCrash.transform.position);
                    float ReiDistance = Vector3.Distance(LocalPlayer.Transform.position, Scene.SceneTracker.planeCrash.transform.position);
                    if (Render.IsOnScreen(WorldToScreen)) {
                        if (ReiDistance < Settings.fPlane) {
                            Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Plane Crash Site", Color.white, true, 12, FontStyle.Normal);
                            Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                        }
                    }
                }

                if (Settings.Yacht) {
                    Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Scene.Yacht.transform.position);
                    float ReiDistance = Vector3.Distance(LocalPlayer.Transform.position, Scene.Yacht.transform.position);
                    if (Render.IsOnScreen(WorldToScreen)) {
                        if (ReiDistance < Settings.fYacht) {
                            Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Yacht", Color.white, true, 12, FontStyle.Normal);
                            Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                        }
                    }
                }

                if (Settings.Cave) {
                    foreach (caveEntranceManager Cave in Scene.SceneTracker.caveEntrances) {
                        if (!Cave) continue;
                        Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Cave.transform.position);
                        float ReiDistance = Vector3.Distance(LocalPlayer.Transform.position, Cave.transform.position);
                        if (Render.IsOnScreen(WorldToScreen)) {
                            if (ReiDistance < Settings.fCave) {
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Cave Entrance", Color.cyan, true, 12, FontStyle.Normal);
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                            }
                        }
                    }
                }

                if (Settings.Sinkhole) {
                    Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(Scene.SinkHoleCenter.transform.position);
                    float ReiDistance = Vector3.Distance(LocalPlayer.Transform.position, Scene.SinkHoleCenter.transform.position);
                    if (Render.IsOnScreen(WorldToScreen)) {
                        if (ReiDistance < Settings.fPlane) {
                            Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Sinkhole", Color.cyan, true, 12, FontStyle.Normal);
                            Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                        }
                    }
                }
            }
        }

        public static string Replace(string pText) {
            pText = pText.Replace("(Clone)", "").Replace("turtleGo","Turtle").Replace("tortoiseGo","Tortoise").Replace("lizardGo", "Lizard").Replace("rabbitGo", "Rabbit").Replace("squirrelGo", "Squirrel").Replace("deerGo", "Deer").Replace("raccoonGo", "Raccoon").Replace("boarGo", "Boar").Replace("crocodileGo", "Crocodile").Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "");
            return new Regex(@"\([\d-]\)").Replace(pText, string.Empty);
        }

        private static readonly HumanBodyBones[] CannibalBones =
        {
            HumanBodyBones.Head,
            HumanBodyBones.Neck,
            HumanBodyBones.Chest,
            HumanBodyBones.LeftShoulder,
            HumanBodyBones.LeftUpperArm,
            HumanBodyBones.LeftLowerArm,
            HumanBodyBones.LeftHand,
            HumanBodyBones.RightShoulder,
            HumanBodyBones.RightUpperArm,
            HumanBodyBones.RightLowerArm,
            HumanBodyBones.RightHand,
            HumanBodyBones.Hips,
            HumanBodyBones.LeftUpperLeg,
            HumanBodyBones.LeftLowerLeg,
            HumanBodyBones.LeftFoot,
            HumanBodyBones.RightUpperLeg,
            HumanBodyBones.RightLowerLeg,
            HumanBodyBones.RightFoot
        };

        private static void Skeleton(Animator animator)
        {
            if (animator == null || !animator.isHuman || !animator.isInitialized) { return; }
            Vector3[] BoneArray = new Vector3[CannibalBones.Length];
            for (int i = 0; i < CannibalBones.Length; i++)
            {
                Transform BonePosition = animator.GetBoneTransform(CannibalBones[i]);
                if (BonePosition != null) BoneArray[i] = Render.WorldToScreenPoint(BonePosition.position);
                else return;
            }
            Color color = Color.white;
            if (Settings.Skeleton)
            {
                Render.DrawLine(BoneArray[0], BoneArray[1], 1f, color);
                Render.DrawLine(BoneArray[1], BoneArray[2], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[3], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[7], 1f, color);
                Render.DrawLine(BoneArray[3], BoneArray[4], 1f, color);
                Render.DrawLine(BoneArray[4], BoneArray[5], 1f, color);
                Render.DrawLine(BoneArray[5], BoneArray[6], 1f, color);
                Render.DrawLine(BoneArray[7], BoneArray[8], 1f, color);
                Render.DrawLine(BoneArray[8], BoneArray[9], 1f, color);
                Render.DrawLine(BoneArray[9], BoneArray[10], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[11], 1f, color);
                Render.DrawLine(BoneArray[11], BoneArray[12], 1f, color);
                Render.DrawLine(BoneArray[11], BoneArray[15], 1f, color);
                Render.DrawLine(BoneArray[12], BoneArray[13], 1f, color);
                Render.DrawLine(BoneArray[13], BoneArray[14], 1f, color);
                Render.DrawLine(BoneArray[15], BoneArray[16], 1f, color);
                Render.DrawLine(BoneArray[16], BoneArray[17], 1f, color);
            }
        }
    }
}
