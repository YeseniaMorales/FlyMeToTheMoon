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
 *  Descripción:  Programa que crea las instancias a los enemigos y los alimentos
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //  Variables de instancia
    public GameObject[] enemigPrefabs;  //  Arreglo de prefabs de enemigos
    public GameObject[] objectPrefabs;  //  Arreglo de prefabs de alimentos
    private float spawnRangeY = 3;      //  Posición en Y de aparición
    private float spawnRangeX = 9;      //  Posición en X de aparición
    private float startDelay = 2;       //  Retardo para la primera aparición de un objeto       
    private float spawnInterval = 3f;   //  Intervalo entre el cual aparecerán los objeto
    public GameManager s;               //  Instancia de la clase Game Manager

    // Start is called before the first frame update
    void Start()
    {
        //  Invoca de forma repetida la función  SpawnRandomEnemig() segun el retardo de inicio y el intervalo de aparición
        InvokeRepeating("SpawnRandomEnemig", startDelay, spawnInterval);
        //  Invoca de forma repetida la función  SpawnRandomAlimen() segun el retardo de inicio y el intervalo de aparición
        InvokeRepeating("SpawnRandomAlimen", startDelay, spawnInterval);
        //  Toma las caracteristicas del Objeto Game Manager
        s = FindObjectOfType<GameManager>();
    }

    void SpawnRandomEnemig()
    {
        //  Si el juego está activo
        if (s.isGameActive == true)
        {
            //  Genera un indice aleatorio para un prefab
            int enemigIndex = Random.Range(0, enemigPrefabs.Length);
            //  Genera una posición aleatoria
            Vector3 spawPos = new Vector3(9.16f, Random.Range(-spawnRangeY, spawnRangeY), 0);
            //  Intancía el objeto
            Instantiate(enemigPrefabs[enemigIndex], spawPos, enemigPrefabs[enemigIndex].transform.rotation);
        }
    }

    void SpawnRandomAlimen()
    {
        //  Si el juego está activo
        if (s.isGameActive == true)
        {
            //  Genera un indice aleatorio para un prefab
            int alimIndex = Random.Range(0, objectPrefabs.Length);
            //  Genera una posición aleatoria
            Vector3 spawPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), 0);
            //  Intancía el objeto
            Instantiate(objectPrefabs[alimIndex], spawPos, objectPrefabs[alimIndex].transform.rotation);
        }
    }
}
