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
        private AudioSource _audio;
        public float shootingSpeed = 2f, range = 1.5f;
        public string Axis;
        private float distanceToObjective;
        public bool inRange, coroutineCalled;


        private void Awake()
        {
            animator = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
        }
        void Update()
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

                //bulletComponent.direction = Vector2.up;

                switch (Axis)
                {
                    case "Right":
                        bulletComponent.direction = Vector2.right;
                        break;
                    case "Left":
                        bulletComponent.direction = Vector2.left;
                        break;
                    case "Down":
                        bulletComponent.direction = Vector2.down;
                        break;
                    default:
                        bulletComponent.direction = Vector2.up;
                        break;
                }
                _audio.Play();
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

            yield return new WaitForSeconds(1);
            coroutineCalled = false;
        }
    }
}
