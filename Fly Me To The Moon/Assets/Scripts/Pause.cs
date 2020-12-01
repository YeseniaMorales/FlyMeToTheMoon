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
 *  Descripción:  Programa que termina el juego mediante teclado
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Update()
    {
        //Si se preciona la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            // Cierra la aplicación
            Application.Quit();
        }
    }
}
