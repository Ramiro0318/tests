using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pruebas
{
    public class Menus : MonoBehaviour
    {
        public Index ActualScene = 0;
        public Index PreviousValidScene;

       
        public void LoadNextScene() 
        {
            switch (ActualScene.Value)
            {
                case 0: SceneManager.LoadScene(1);
                    ActualScene = 1;
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

        public void Quit() 
        {
            Debug.Log("Leaving...");
            Application.Quit();
        }
    }
}
