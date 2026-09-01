using UnityEngine;

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

                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
