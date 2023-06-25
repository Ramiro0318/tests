using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Pruebas
{
    public class Slime_0 : MonoBehaviour
    {
        public GameObject Projectile;
        public GameObject Shooter;
        public GameObject Objective;
        private Animator animator;
        public float shootingSpeed = 2f, range = 1.5f;
        private float distanceToObjective;
        public bool inRange;


        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        void Update()
        {
            distanceToObjective = Vector2.Distance( transform.position, Objective.transform.position);
            //inRange = Physics.CheckSphere(transform.position, range, capaDeJugador);

            if (distanceToObjective <= range) 
            {
                inRange = true;
                if (Time.time % shootingSpeed <= 0.005f)
                {
                    StartCoroutine(ShootingTiming());
                    //Invoke("Shoot", 1f);
                }
            }
            else { inRange = false; }
        }

        private void LateUpdate()
        {
            if (inRange)
            {
                animator.SetBool("InRange",true);
            }
            else { animator.SetBool("InRange",false); }
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position,range);
        }

        IEnumerator ShootingTiming() 
        {
            Debug.Log("Shoot!");
            Invoke("Shoot", 1f);

            yield return new WaitForSeconds(2);
        }
    }
}
