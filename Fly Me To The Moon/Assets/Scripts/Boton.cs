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
 *  Descripción:  Programa que da función al botón que inicia el juego 
 *
 **************************************************************************** */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    //Variables de instancia
    public bool isGameActive;           //Bandera que indica que el juego ha iniciado
    private GameManager gameManagerX;   //Intancia de la clase GameManager
    public GameObject titleScreen;      //Objeto que instancia el mensaj de inicio en la pantalla

    void Start()
    {
        //Se toman las propiedades del objeto Game Manager
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    
    public void Pulsar()
    {
        //Si se preciona el botón
        isGameActive = true;                        //Levanta la bandera de que el juego ha iniciado
        titleScreen.SetActive(false);               //Deaparece el mensaje de patalla
        gameManagerX.isGameActive = isGameActive;   //Le indica al manejador de juego que e ha presionado el botón y debe iniciar
        Debug.Log("Boton de inicio presionado");    //Muestra en consola que e ha presionado el botón
    }
}
