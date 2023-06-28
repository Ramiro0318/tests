using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pruebas
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 2f, livingTime = 3f;
        public int damage = 10;
        public Vector2 direction;
        private Rigidbody2D _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start () 
        {
            Destroy(gameObject, livingTime);
        }

        private void Update()
        {
            Invoke("Shoot",1f * Time.deltaTime);
            // verify colission

        }

            
        public void Shoot()
        {
            Vector2 movement = direction.normalized * speed;
            //transform.Translate(movement);
            _rigidbody.velocity = movement;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {

                Debug.Log("Player hit");
                Destroy(gameObject);

                //Invoke("GetDamage",1f); // How???

                collision.gameObject.GetComponent<PlayerHealth>().AddDamage(damage);


                //    if (collision.tag == "Projectiles") 
                //    {
                //        Debug.Log("Hit another projectile");
            }


        }

    }
}
