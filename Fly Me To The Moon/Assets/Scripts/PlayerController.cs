/*---------------------------------------------------------
 *  Fly me to the moon 
 *---------------------------------------------------------*/

/* *****************************************************************************
 *  Autores:    
 *            			
 *            Claudia Alejandra Gonzalez Ibarra 		
 *            Juan Humberto Herrera Martinez 		
 *            Yesenia America Morales Diaz de Leon	 	
 *            
 *  Descripción:  Programa que controla los movimientos del jugador
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //  Variables de instancia
    private Animator animator;              //  Intancia de las animaciones

    private float fuerzaSalto = 350.0f;     //  Variable que cntrola la fuerza del salto
    private float velocidad = 1.5f;         //  Variable que almacena la velocidad para avanzar
    private float xlimite = 9.0f;           //  Variable que almacena límite en X
    private bool puedeSaltar = true;        //  Bandera que controla el salto
    public int score = 0;                   //  Variable que almacena la puntuación

    private Rigidbody2D rb;                 //  Instancia de Rigid Body del jugador
    private SpriteRenderer spriteRenderer;  //  Instancia de Sprite Renderer del jugador 
    private AudioSource playerAudio;        //  Instancias de audio
    public AudioClip golpe;
    public AudioClip comerA;

    public GameManager s;                   //  Instancia de la clase Game Manager

    void Start()
    {
        //  Accede a las animaciones del jugador
        animator = GetComponent<Animator>();

        //  Accede al Rigid Body del jugador
        rb = GetComponent<Rigidbody2D>();

        //  Accede al Sprite Renderer del jugador
        spriteRenderer = GetComponent<SpriteRenderer>();

        //  Accede a las caracteristicas del Game Manager
        s = FindObjectOfType<GameManager>();

        //  Accede a la fuente de audio del jugador
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //  Si el juego ha iniciado
        if (s.isGameActive == true)
        {
            //  Toma la entrada del contol horizontal (Flechas del teclado)
            float entrada = Input.GetAxis("Horizontal");

            //  Si la entrada es menor a 0 (movimiento a la izquierda)
            if (entrada < 0)
            {
                //  Gira horizontalmente el prite a la izquierda
                spriteRenderer.flipX = false;
                //  Activa la animación de correr
                animator.SetBool("isRunning", true);
            }
            //  Si la entrada es mayor a 0 (movimiento a la derecha)
            else if (entrada > 0)
            {
                //  Gira horizontalmente el prite a la derecha
                spriteRenderer.flipX = true;
                //  Activa la animación de correr
                animator.SetBool("isRunning", true);
            }
            else // de lo contrario se desactiva la animación
            {
                animator.SetBool("isRunning", false);
            }

            //  Si se preciona la tecla espacio y la bandera para altar está activa
            if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
            {
                //  Desactiva la bandera (Para evitar saltos dobles)
                puedeSaltar = false;

                // Desactiva animaciones de correr
                animator.SetBool("isRunning", false);

                //  Activa la animación de salto
                animator.SetBool("isJumping", true);

                //  Agrega fuerza para generar el salto
                rb.AddForce(new Vector2(0, fuerzaSalto));
            }

            //  Se está activada la animación de altar
            if (animator.GetBool("isJumping"))
            {
                //  Duplica la velocidad
                velocidad = 3.0f;
            }
            else // De lo contrario
            {
                //  Mantiene la velocidad en 1.5
                velocidad = 1.5f;
            }

            //  La posición del personaje cambia en función a la velocidad y la entrada horizontal
            transform.position = new Vector3(transform.position.x + velocidad * Time.deltaTime * entrada, transform.position.y, transform.position.z);

            //  si el personaje sale de la pantalla por la derecha
            if (transform.position.x > xlimite)
            {
                // Aparece del lado izquierdo
                transform.position = new Vector3(-xlimite + velocidad * Time.deltaTime * entrada, transform.position.y, transform.position.z);
            }

            //  si el personaje sale de la pantalla por la izquierda
            if (transform.position.x < -xlimite)
            {
                // Aparece del lado derecho
                transform.position = new Vector3(xlimite + velocidad * Time.deltaTime * entrada, transform.position.y, transform.position.z);
            }
        }
        

    }

    // En caso de coliciones
    private void OnCollisionEnter2D(Collision2D colliion)
    {
        //  Si choca con el suelo
        if(colliion.gameObject.tag == "Suelo")
        {
            //  significa que puede saltar
            puedeSaltar = true;
            //  Desactiva la animación de salto
            animator.SetBool("isJumping", false);
        }

        //  Si choca con un enemigo
        if (colliion.gameObject.tag == "enemigo")
        {
            //  Se activa la animación de caer
            animator.SetBool("isFalling", true);

            //  Destruye el objeto con el que chocó
            Destroy(colliion.gameObject);

            //  Resta un punto
            s.golpe(1);

            //  Reproduce el audio de golpe
            playerAudio.PlayOneShot(golpe, 2.0f);   
        }
        else // De lo contrario
        {
            //La animación de caida e desactiva
            animator.SetBool("isFalling", false);
        }

        // i choca con comida
        if (colliion.gameObject.tag == "comida")
        {
            //  Desaparece la comida
            Destroy(colliion.gameObject);

            //  Aumenta un punto
            s.comer(1);

            //  Reproduce sonido de ganar puntos
            playerAudio.PlayOneShot(comerA, 2.0f);

        }

        //  Si choca con el fondo (Significa que perdió)
        if (colliion.gameObject.tag == "fondo")
        {
            //  Reproduce aundio de perder
            playerAudio.PlayOneShot(golpe, 2.0f);

            // Envía el mensaje de Game Over
            s.GameOver();

            // Destruye el jugador
            Destroy(this.gameObject);
        }
    }
}
