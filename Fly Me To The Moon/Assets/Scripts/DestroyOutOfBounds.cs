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
 *  Descripción:  Programa que detruye los obstaculos al salir de la pantalla
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //  Variables de instancia
    private float topLeft = -9.16f; // Variable que establece limite izquierdo de la pantalla

    void Update()
    {
        //Si el objeto revasa el limite izquierdo
        if (transform.position.x < topLeft)
        {
            Destroy(gameObject);    //Lo destruye
        }
    }
}
