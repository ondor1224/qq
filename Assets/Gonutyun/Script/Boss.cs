
using UnityEngine;


namespace Gonutyun
{
    public class Boss : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        GameManager gameManager;
        Player player;
        public GameObject objBullet;
        public GameObject BulletPoint;
        public float bossMissileTime;
        public float bossTempTime;
        void Start()
        {
            GameObject gamManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            if (gamManagerObject != null)
            {
                gameManager = gamManagerObject.GetComponent<GameManager>();


            }
            if(gamManagerObject == null)
            {
                Debug.Log("게임 매니저가 존재하지 않습니다.");

            }
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if(player == null)
            {
                Debug.LogError("플레이어가 존재하지 않습니다.");
            }

           
            
        }

        void BossFirBullet(int num)
        {
            switch (num)
            {
                case 0:
                    {
                        GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                        bullet.GetComponent<Bullet>().SetBullet(player.transform.position);
                    }
                    break;
                case 1:
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                            bullet.GetComponent<Bullet>().SetBullet
                                (player.transform.position + Vector3.forward + new Vector3(-1 + i, 0, 0));

                        }
                        break;
                    }
            }
        }

        void Update()
        {
            
            if (bossTempTime > bossMissileTime)
            {
                bossTempTime = 0;
                BossFirBullet(Random.Range(0, 2));
            }
            
            bossTempTime += Time.deltaTime;
        }



        
    }
}
