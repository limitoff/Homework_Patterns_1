using System;
using UnityEngine;

namespace FactoryMethod
{
    public sealed class CreatorEnemies : MonoBehaviour
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private float _hp;
        private ICreatorEnemy _creatorEnemy;
        private void Start()
        {
            switch (_enemyType)
            {
                case EnemyType.None:
                case EnemyType.Small:
                    _creatorEnemy = new SmallEnemyFactory();
                    break;
                case EnemyType.Big:
                    _creatorEnemy = new BigEnemyFactory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // var enemy = Instantiate(Resources.Load<SmallEnemy>(AssetPath.Enemies[EnemyType.Small]));

            //var enemy = Enemy.CreateSmallEnemy(new Hp());

            var enemy = _creatorEnemy.Create(new Hp(_hp));

            enemy.Hp.HP -= 5;
        }
    }
}
