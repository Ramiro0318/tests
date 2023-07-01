using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

namespace Pruebas
{
    public class PlayerHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        public int health;

        private SpriteRenderer _rednderer;

        private void Awake()
        {
            _rednderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            health = maxHealth;
        }

        public void AddDamage( int amount) 
        {
            StartCoroutine(ColorFeedBack());
            health -= amount;
            if (health <= 0) 
            {
                health = 0;
            }
            Debug.Log($"The Player has been hit, currently life is : {health}");
        }
        
        public void AddHealth( int amount) 
        {
            health -= amount;
            if (health >= maxHealth) 
            {
                health = maxHealth;
            }
            Debug.Log($"The Player has been healed, currently life is : {health}");
        }

        private IEnumerator ColorFeedBack() 
        {
            _rednderer.color = Color.red;
            yield return new WaitForSeconds(.2f);
            _rednderer.color = Color.white;
            
        }
    }
}
