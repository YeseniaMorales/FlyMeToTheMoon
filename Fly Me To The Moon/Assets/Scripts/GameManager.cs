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
 *  Descripción:  Programa que controla los aspecto generales del juego
 *
 **************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables de instancia
    public Renderer fondo;                  //  Instancia del fondo del juego
    public bool isGameActive;               //  Bandera que notifica si el juego ha iniciado
    private int score=0;                    //  Variable que almacena la puntuación
    public GameObject titleScreen;          //  Instancia del titulo en pantalla
    public Button restartButton;            //  Instancia del botón de restaurar
    public TextMeshProUGUI scoreText;       //  Instancia de tecto de puntaje
    public TextMeshProUGUI gameOverText;    //  Instancia del menaje de Game Oveer
 
    // Al iniciar el juego
    void Start()
    {
        //  Toma las caractristicas del objeto identificado para el score
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        //  Inicializa el Score con 0
        scoreText.text = "Score: 0"; 
    }

    public void StartGame()
    {
        Debug.Log("Inicio");
        //  Mientras el juego esté activo
        while (isGameActive)
        {
            if (isGameActive)
            {   
                //  El fondo se moverá hacia abajo
                fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0, 0.05f) * Time.deltaTime;
            }
        }
    }

    // Detiene el juego y muestra el texto de  Game over
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Recarga el juego reestableciendo la escena
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void Update()
    {   
        //  Si el punteje es menor a 0
        if (score < 0)
        {
            //  Terina el juego
            Debug.Log("Game Over!");
            GameOver();
        }
        else // De lo contrario
        {
            //Actualiza el contador de puntos
            scoreText.text = "Score: " + score;
            Debug.Log(score);
        }
    }
    
    //  Método de golpe
    public void golpe(int num)
    {
        //  Reduce los puntos
        score = score - num;
    }

    //  Método para comer
    public void comer(int num)
    {
        //  Acumula puntos
        score = score + num;
    }
}
