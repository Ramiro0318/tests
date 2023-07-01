using Pruebas;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float tickTimer = 0f, idleTimer = 0f;
    public int life;
    public bool isDeath;

    public Vector2 horizontalMovement, verticalMovement;
    public Vector2 movement2axis;
    private Animator animator;
    public GameObject GameOverFadeOut;
    
    float horizontalInput, verticalInput;
 
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        #region MovimientoPrimitivo
        //Vector2 movement = direccion.normalized * speed * Time.deltaTime;
        ////transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        //transform.Translate(movement);

        // Un eje a la vez
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //horizontalMovement = new Vector2(horizontalInput * speed * Time.deltaTime, 0f);
        //transform.Translate(horizontalMovement);

        //float verticalInput = Input.GetAxisRaw("Vertical");
        //verticalMovement = new Vector2(0f, verticalInput * speed * Time.deltaTime);
        //transform.Translate(verticalMovement);
        #endregion

        //Intentando con los dos ejes al mismo tiempo
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movement2axis = new Vector2(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime);
        transform.Translate(movement2axis);
        life = GetComponent<PlayerHealth>().health;
    }

    private void LateUpdate()
    {
        animator.SetFloat("X axis float", horizontalInput);
        animator.SetFloat("Y axis float", verticalInput);

        if (movement2axis == Vector2.zero)
        {
            idleTimer += Time.deltaTime;  
            animator.SetBool("IsWalking", false);
        }
        else
        {
            idleTimer = 0f;
        }

        if (Input.GetButton("Horizontal") | Input.GetButton("Vertical") )
        {
            animator.SetBool("IsWalking", true);
        }
        else { animator.SetBool("IsWalking", false); }

        //Idle
        if (idleTimer > 10) 
        {
            animator.SetBool("IsIdle", true);
        }
        else { animator.SetBool("IsIdle", false); }

        //Death
        if (0 >= life & !isDeath)
        {
            isDeath = true;
            animator.SetTrigger("Death");
            GameOverFadeOut.SetActive(true);
        }
    }
}

