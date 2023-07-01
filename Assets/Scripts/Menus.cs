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
        public Index ActualScene = 0;
        public Index PreviousValidScene;

        private void Scene2loader()
        {
            SceneManager.LoadScene(2);
        }

        public void LoadNextScene() 
        {
            switch (ActualScene.Value)
            {
                case 0: Invoke("Scene2loader", 0.7f );
                    ActualScene = 2;
                    break;
                case not 0 and not 1: 
                    SceneManager.LoadScene(ActualScene.Value + 1);
                    PreviousValidScene = ActualScene.Value;
                    ActualScene =  ActualScene.Value + 1;
                    break;
                default: SceneManager.LoadScene(PreviousValidScene.Value);
                    break;
            }
        }

        public void ResetScene() 
        {
            SceneManager.LoadScene(ActualScene.Value);
        }

        public void Quit() 
        {
            Debug.Log("Leaving...");
            Application.Quit();
        }
    }
}
