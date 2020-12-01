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
 *  Descripción:  Programa que genera el movimiento de los obstáculos
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //Variables de instancia
    public float speed = 4.0f;  //Velocidad en que se mueve el objeto

    void Update()
    {
        //Cambia la posición del vector de izquierdo con respecto del tiempo y la velocidad
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
