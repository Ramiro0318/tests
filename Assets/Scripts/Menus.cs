using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pruebas
{
    public class Menus : MonoBehaviour
    {
        public Index ActualScene;
        public Index PreviousValidScene;
        public int sceneNumber;

        //private void Scene2loader()
        //{
        //    sceneNumber = 2;
        //    Debug.Log(sceneNumber);
        //    SceneManager.LoadScene(sceneNumber);
        //}

        public void LoadNextScene() 
        {
            switch (ActualScene.Value)
            {
                //case 0: Invoke("Scene2loader", 0.7f );
                //    break;
                //case not 0 and not 1: 
                //    SceneManager.LoadScene(ActualScene.Value + 1);
                //    PreviousValidScene = ActualScene.Value;
                //    ActualScene =  ActualScene.Value + 1;
                //    break;
                //default: SceneManager.LoadScene(PreviousValidScene.Value);
                //    break;
                case 0 : SceneManager.LoadScene(2);
                    sceneNumber = 2;
                    Debug.Log(sceneNumber);
                    break;
                case 2: SceneManager.LoadScene(3);
                    sceneNumber = 3;
                    break;
                case 3: SceneManager.LoadScene(4);
                    sceneNumber = 4;
                    break;
                case 4: SceneManager.LoadScene(5);
                    sceneNumber = 5;
                    break;
                default: break;
            }
        }

        public void ResetScene() 
        {
            //StartCoroutine("ResetSceneCoroutine");
            Invoke("ResetScene_",2f);
            Debug.Log(sceneNumber);
        }

        private void ResetScene_() 
        {
            SceneManager.LoadScene(sceneNumber);  
        }
        public void ToMainMenu() 
        {
            SceneManager.LoadScene(0);
            sceneNumber = 0;
            Debug.Log(sceneNumber);
        }

        public void Quit() 
        {
            Debug.Log("Leaving...");
            Application.Quit();
        }
    }
}
