using UnityEngine;
using UnityEngine.UI;

namespace Gonutyun
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public float bulletTime = 0.1f;
        [SerializeField] public float reloadTime = 0f;
        [SerializeField] public float speed = 2.0f;

        public GameObject objBullet;
        public Transform BulletPoint;
        public float Hp;
        public int Upgrade;
        public int Bomb;




        private Rigidbody thisRigi;
        //private GameManager gameManager;

        void Start()
        {
            thisRigi = GetComponent<Rigidbody>();
            //gameManager = FindFirstObjectByType<GameManager>();
        }

        void Update()
        {
            Move();
            FireBullet();
        }

        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveX, 0.0f, moveZ);

            thisRigi.linearVelocity = move * speed;

            Vector3 posInWorld =
                Camera.main.WorldToScreenPoint(transform.position);

            float posX = Mathf.Clamp(posInWorld.x, 0, Screen.width);
            float posZ = Mathf.Clamp(posInWorld.y, 0, Screen.height);

            Vector3 posInScreen = Camera.main.ScreenToWorldPoint(
                new Vector3(posX, posZ, 0)
            );

            thisRigi.position =
                new Vector3(posInScreen.x, 0, posInScreen.z);
        }

        private void FireBullet()
        {
            reloadTime += Time.deltaTime;

            if (Input.GetButton("Fire1") && reloadTime >= bulletTime)
            {
                reloadTime = 0f;

                GameObject bullet = Instantiate(
                    objBullet,
                    BulletPoint.position,
                    transform.rotation
                );

                bullet.GetComponent<Bullet>().SetBullet(
                    BulletPoint.position + Vector3.forward
                );
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                    Destroy(other.gameObject);
                    Destroy(gameObject);
            }
        }
    }
}