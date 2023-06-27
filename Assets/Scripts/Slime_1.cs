using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

namespace Pruebas
{
    public class Slime_1 : MonoBehaviour
    {
        public GameObject Projectile;
        public GameObject Shooter;
        public GameObject Objective;
        private Animator animator;
        public float shootingSpeed = 1f, range = 1f;
        private float distanceToObjective;
        public bool inRange, coroutineCalled;
        private FunctionTimer functionTimer;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Update()
        {
            distanceToObjective = Vector2.Distance(transform.position, Objective.transform.position);
            
            if (distanceToObjective <= range)
            {
                inRange = true;
                if (!coroutineCalled)
                {
                    StartCoroutine(ShootingTiming());
                    coroutineCalled = true;
                }
                //functionTimer = new FunctionTimer(Shoot,1f);
                ////Debug.Log("Big Shooting");
                
                ////functionTimer.Update();
                ////InvokeRepeating("Shoot", 1f, 0.5f);
            }
            if (distanceToObjective > range)
            {
                coroutineCalled = false;
                inRange = false;
                CancelInvoke("Shoot");
            }
        }

        private void FixedUpdate()
        {
            if (inRange) 
            {
                animator.SetBool("InRange", true);
            }
            else { animator.SetBool("InRange", false); }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, range);
        }
        
        private void Shoot()
        {
            if (Projectile != null & Shooter != null)
            {
                GameObject bigBullet = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;

                Bullet bigBulletComponent = bigBullet.GetComponent<Bullet>();

                bigBulletComponent.direction = Objective.transform.position;
            }
        }

        IEnumerator ShootingTiming()
        {
            while (inRange == true && coroutineCalled == false)
            {
                Debug.Log("Big Shoot!");
                InvokeRepeating("Shoot", 1f,1f);

                yield return null; //new WaitForSeconds(1);
            }
        }
    }
}
