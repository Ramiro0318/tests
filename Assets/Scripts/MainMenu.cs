using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pruebas
{
    public class MainMenu : MonoBehaviour
    {
        private Animator _animator;
        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void GoSettings()
        {
            _animator.SetBool("GoSettings", true);
        }
        public void ReturnSettings()
        {
            _animator.SetBool("GoSettings", false);
        }

    }
}
