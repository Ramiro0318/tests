using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pruebas
{
    public class FunctionTimer
    {
        private Action action;
        public float timer;
        public bool isDestryed;
        float saveTimer;

        public FunctionTimer(Action action, float timer)
        {
            this.action = action;
            this.timer = timer;
            isDestryed = false;
        }

        public void Update()
        {
            //saveTimer = timer;
            //Reset();
            if (!isDestryed)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    action();
                    DestroySelf();
                    //timer = saveTimer;
                }
            }
        }

        private void DestroySelf()
        {
            isDestryed = true;        
        }
        //private void Reset()
        //{
        //    isDestryed = false;        
        //}

    }
}
