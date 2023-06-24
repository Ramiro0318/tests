using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Pruebas
{
    public class Slime_0 : MonoBehaviour
    {
        public GameObject Projectile;
        public GameObject Player;
        public GameObject Shooter;
        public float shootingSpeed = 2f;
        
        Vector2 direction;
        Vector2 range;
        void Start () 
        {
            //Invoke("Shoot", 2f);
            //Invoke("Shoot", 3f);
            //Invoke("Shoot", 4f);
            //Invoke("Shoot", 5f);

            range = new Vector2(2,2);
            
            {

            }
        
        }

        void Update()
        {
            if (Time.time % shootingSpeed <= 0.01f) 
            {
                Invoke("Shoot",1f);
            
            }

        }
        

        void Shoot() 
        {
            if (Projectile != null && Shooter != null)
            {

                GameObject myBullet = Instantiate(Projectile,transform.position,Quaternion.identity) as GameObject;
            
                Bullet bulletComponent = myBullet.GetComponent<Bullet>();

                bulletComponent.direction = Vector2.up;
            }
        }
    }
}
