using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        public Text Hp;
        public Text Upgrade;
        public Text Bomb;
        public Text score;

        public float bossTime;
        public Boss bossScript;
        public bool isBoss = false;
        public GameObject Boss;
        public float gameTime;



       



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


            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.Hp = GameDataManager.instance.maxHp;
            player.Upgrade = GameDataManager.instance.upgrade;
            player.Bomb = GameDataManager.instance.bomb;
            player.Score = GameDataManager.instance.gameScore;

            Hp.text = "Hp:" + player.Hp;
            Upgrade.text = "Upgrade:" + player.Upgrade;
            Bomb.text = "Bomb:" + player.Bomb;
            score.text = "Score:" + player.Score;
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
            if (!isBoss)
            {
                if (gameTime > bossTime)
                {
                    StopAllCoroutines();
                    Invoke("BossInit", 2.0f);
                    isBoss = true;
                }
            }
            gameTime += Time.deltaTime;
        }

        void BossInit()
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);
            Instantiate(Boss, spawnPosition, Boss.transform.rotation);
        }

    }
}