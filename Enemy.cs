using System.Collections;
using UnityEngine;


namespace FactoryMethod
{
    public abstract class Enemy : MonoBehaviour
    {
        public Hp Hp;

        public static SmallEnemy CreateSmallEnemy(Hp hp)
        {
            var enemy = Instantiate(Resources.Load<SmallEnemy>(AssetPath.Enemies[EnemyType.Small]));
            enemy.Hp = hp;
        
            return enemy;
        }

        public static BigEnemy CreateBigEnemy(Hp hp)
        {
            var enemy = Instantiate(Resources.Load<BigEnemy>(AssetPath.Enemies[EnemyType.Big]));
            enemy.Hp = hp;

            return enemy;
        }

        public void SetHP(Hp hp)
        {
            Hp = hp;
        }

        public abstract void Fire();

        private IEnumerator Start()
        {
            while (true)
            {
                Fire();
                yield return new WaitForSeconds(3.0f);
            }
        }
    }
}
