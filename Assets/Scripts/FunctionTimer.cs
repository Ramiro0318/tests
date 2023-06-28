using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pruebas
{
    /* Pendiente de verificar
     * Solo funciona en una ocación
     * verificar el video
     * https://www.youtube.com/watch?v=1hsppNzx7_0&t=596s
     */

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
            if (!isDestryed)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    action();
                    DestroySelf();
                }
            }
        }

        private void DestroySelf()
        {
            isDestryed = true;        
        }
    }
}
