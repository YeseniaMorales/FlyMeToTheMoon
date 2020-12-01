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
 *  Descripción:  Programa que controla el movimiento de las plataformas
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    //Variables de instancia
    public float velocidad = .5f;               //  Variable que almacena la velocidad incial
    public float incrementoVelocidad = 0.1f;     //  Variable que almacena el incremento en la velocidad
    public float lapso = 1.5f;                    //  Variable que almacena el lapso en que se incrementará la velocidad
    public GameManager s;                       //  Instancia de la clase Game Manager

    void Start()
    {
        //Toma las caracteristicas del Objeto Game Manager
        s = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //  Si el juego está activo 
        if ( s.isGameActive == true )
        {
            //  Cambia la posición en Y del objeto con respecto a la velocidad
            transform.position += new Vector3(0, -0.005f, 0)  * velocidad;

            //  Si la posición en Y de la plataforma sale de la pantalla
            if ( transform.position.y < -5.0f )
            {
                //Se le asigna una nueva posición ensima de la pantalla para que aparezca nuevamente
                transform.position = new Vector3( Random.Range( -9.0f, 9.0f), 4.8f, 0 );
            }
            //  Si el tiempo de juego supera el lapso de espera
            if (Time.time > lapso)
            {
                velocidad += incrementoVelocidad;   // La velocidad aumenta con respecto al incremento
                lapso += 1.5f;                      //  Se aumenta el lapso de espera
            }
        }
        else // De no estar activo el juego
        {
            velocidad = .5f;            //  La velocidad se mantiene en 0.5
            lapso = Time.time + 1.5f;   //  El lapso se cmantiene en 1.5 con respecto al tiempo de juego
        }
    }
}
