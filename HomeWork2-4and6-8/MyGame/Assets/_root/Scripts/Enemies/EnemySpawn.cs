using UnityEngine;

namespace Enemies
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        //[SerializeField] int maxCountEnemy = 3;

        //private GameObject enemy;
        //private int countEnemy = 0;

        //private List<GameObject> enemyPool;


        private void Start()
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        }

        //private void Update()
        //{
        //    if (enemy == null && countEnemy < maxCountEnemy)
        //    {
        //        enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        //        countEnemy += 1;
        //    }
        //}
    }
}