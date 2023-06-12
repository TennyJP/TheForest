using UnityEngine;
namespace ReiHook.Features.Miscellaneous {
    public class Spawn : MonoBehaviour {
        private static GameObject EnemySpawner = null;
        public static void SpawnEnemy(EnemyType enemyType, int amount, Vector3 position, Vector3 positionOffset) {
            Vector3 spawnLocation = position + positionOffset;
            Quaternion spawnRotation = UnityEngine.Random.rotation;
            EnemySpawner = Instantiate(Resources.Load<GameObject>("instantMutantSpawner"), spawnLocation, spawnRotation);
            AddEnemy(ref EnemySpawner, enemyType, amount);
            EnemySpawner.GetComponent<spawnMutants>().range = 2f;
            EnemySpawner.GetComponent<spawnMutants>().SendMessage("doSpawn");
            ResetEnemyAmount(ref EnemySpawner);
        }

        private static void AddEnemy(ref GameObject obj, EnemyType enemyType, int amount) {
            spawnMutants Mutants = obj.GetComponent<spawnMutants>();
            switch (enemyType) {
                case EnemyType.skinMaskMale:
                    Mutants.amount_male = amount;
                    Mutants.skinnedTribe = true;
                    break;
                case EnemyType.regularMale:
                    Mutants.amount_male = amount;
                    break;
                case EnemyType.regularFemale:
                    Mutants.amount_female = amount;
                    break;
                case EnemyType.skinnyMale:
                    Mutants.amount_male_skinny = amount;
                    break;
                case EnemyType.skinnyFemale:
                    Mutants.amount_female_skinny = amount;
                    break;
                case EnemyType.paleMale:
                    Mutants.amount_pale = amount;
                    Mutants.pale = true;
                    break;
                case EnemyType.paleFemale:
                    Mutants.amount_pale = amount;
                    Mutants.pale = true;
                    break;
                case EnemyType.skinnyMalePale:
                    Mutants.amount_skinny_pale = amount;
                    Mutants.pale = true;
                    break;
                case EnemyType.skinnyFemalePale:
                    Mutants.amount_skinny_pale = amount;
                    Mutants.pale = true;
                    break;
                case EnemyType.regularMaleFireman:
                    Mutants.amount_fireman = amount;
                    break;
                case EnemyType.regularMaleLeader:
                    Mutants.amount_male = amount;
                    break;
                case EnemyType.creepyArmsy:
                    Mutants.amount_armsy = amount;
                    break;
                case EnemyType.creepyBaby:
                    Mutants.amount_baby = amount;
                    break;
                case EnemyType.creepyFat:
                    Mutants.amount_fat = amount;
                    break;
                case EnemyType.creepySpiderLady:
                    Mutants.amount_girl = amount;
                    break;
                case EnemyType.blueCreepyArmsy:
                    Mutants.amount_armsy = amount;
                    Mutants.pale = true;
                    break;
                case EnemyType.blueCreepySpiderLady:
                    Mutants.amount_girl = amount;
                    Mutants.pale = true;
                    break;
            }
        }

        private static void ResetEnemyAmount(ref GameObject obj) {
            spawnMutants Mutants = obj.GetComponent<spawnMutants>();
            Mutants.amount_male = 0;
            Mutants.amount_female = 0;
            Mutants.amount_male_skinny = 0;
            Mutants.amount_female_skinny = 0;
            Mutants.amount_pale = 0;
            Mutants.amount_skinny_pale = 0;
            Mutants.amount_fireman = 0;
            Mutants.amount_vags = 0;
            Mutants.amount_armsy = 0;
            Mutants.amount_baby = 0;
            Mutants.amount_fat = 0;
        }
    }
}
