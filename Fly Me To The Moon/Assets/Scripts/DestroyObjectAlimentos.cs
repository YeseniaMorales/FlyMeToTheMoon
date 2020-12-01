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
 *  Descripción:  Programa que detruye los alimentos instanciados después de 
 *                cierto tiempo 
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAlimentos : MonoBehaviour
{
    void Start()
    {   // Destruye los alimentos instanciados despues de cinco segundos
        Destroy(gameObject, 5);
    }
}
