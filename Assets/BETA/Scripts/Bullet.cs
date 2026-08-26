using System;
using UnityEngine;

namespace BETA7
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        public float speed = 1.0f;
        public Vector3 dir;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position += dir.normalized * Time.deltaTime * speed;
        }

        public void SetBullet(Vector3 _destination)
        {
            destination = _destination;
            dir = destination - this.transform.position;
        }

       
    }
}
