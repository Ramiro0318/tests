using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pruebas
{
    public class HealthBar : MonoBehaviour
    {
        private Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }
        public void InitHealthBar(float Health) 
        {
            MaxHealth(Health);
            CurrentHealth(Health);
        }

        public void MaxHealth(float maxHealth) 
        {
            slider.maxValue = maxHealth;
        }
        public void CurrentHealth(float Health) 
        {
            slider.value = Health;
        }

    }
}
