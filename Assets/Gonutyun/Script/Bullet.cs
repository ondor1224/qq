using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Gonutyun
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;

        [UnityEngine.SerializeField]
        private bool isThrow = false;

        private Vector3 dir;

        public float speed = 1.0f;
        public bool isPlayer = true;

        public GameObject Item;


        void Update()
        {
            //if (isThrow)
            //{
                transform.position +=
                    dir.normalized * Time.deltaTime * speed;

                //if (Vector3.Distance(transform.position, destination) < 0.1f)
                //{
                //    isThrow = false;
                //}
            //}
        }

        void Start()
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
        }

        public void SetBullet(Vector3 _destination)
        {
            destination = _destination;

            dir = destination - transform.position;

            isThrow = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isPlayer)
            {
                if (other.CompareTag("Enemy"))
                {
                    Instantiate(Item, this.transform.position, Item.transform.rotation);

                    Player player = GameObject.Find("Player").GetComponent<Player>();
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                    player.Score += 1;
                    gameManager.score.text = "score:" + player.Score.ToString();
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                    
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(gameObject);
                    Player player = GameObject.Find("Player").GetComponent<Player>();
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                    if (player.Hp==0)
                    {
                        Destroy(other.gameObject);
                        Destroy(this.gameObject);

                    }
                    
                    else
                    {
                        player.Hp -= 1;
                        gameManager.Hp.text = "Hp:" + player.Hp.ToString();

                    }
                    
                }

                
            }
        }
    }
}
