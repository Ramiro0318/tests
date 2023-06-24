using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pruebas
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 2f, livingTime = 3f;
        public Vector2 direction;

        private void Start () 
        {
            Destroy(gameObject, livingTime);
        }
        private void Update()
        {
            Shoot();
        }

        public void Shoot()
        {
            Vector2 movement = direction.normalized * speed * Time.deltaTime;
            transform.Translate(movement);
        
        }
    }
}
