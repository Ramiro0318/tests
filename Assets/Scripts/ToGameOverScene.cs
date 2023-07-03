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
            //if (invoked ==false)       
            //{ 
            //    invoked = true;
            //    Invoke("ToGOStrean", 2.5f);
            //}
        }

        public void ToGOScrean(bool isDead) 
        {
            if (isDead) 
            {
                StartCoroutine("GameOverCoroutine");
            }
        }
        private IEnumerator GameOverCoroutine() 
        {
        
            animator.SetTrigger("ChangeScene");
            Debug.Log("GameOver Scene");
            yield return new WaitForSeconds(2.5f);
            SceneManager.LoadScene(1);
        }
    }
}
