using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gonutyun
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] Enemys;
        public Vector3 spawnvalue;
        public int enemyCount;
        public float spawnWait;
        public float startWait;
        public float waveWait;

        public List<GameObject> listEnemys = new List<GameObject>();

        public enum GameStatus
        {
            none,
            play,
            gameOver,
            gameClear
        }

        public GameStatus gameStatus = GameStatus.none;

        void Start()
        {
            gameStatus = GameStatus.play;
            StartCoroutine(SpawnEnemy());
        }

        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    GameObject enemy = Enemys[Random.Range(0, Enemys.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(
                        -spawnvalue.x, spawnvalue.x),
                        spawnvalue.y, spawnvalue.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    listEnemys.Add(Instantiate(enemy, spawnPosition, enemy.transform.rotation));
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }

        void Update()
        {

        }
    }
}