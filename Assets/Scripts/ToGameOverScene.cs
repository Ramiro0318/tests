using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pruebas
{
    public class ToGameOverScene : MonoBehaviour
    {
        //private Player player;
        public Animator animator;
        public bool invoked;

        private void Update()
        {
            if (invoked ==false)       
            { 
                invoked = true;
                animator.SetTrigger("ChangeScene"); 
                Invoke("ToGOStrean", 2.5f);
            }
        }

        private void ToGOStrean() 
        {
            SceneManager.LoadScene(1);
        }
    }
}
