using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    GameObject gameOver;
    GameObject youWin;
    int puntos = 0;
    int faltantes = 72;
    int enemigos = 7;
    public TextMeshProUGUI puntosT;
    public TextMeshProUGUI faltantesT;
    public TextMeshProUGUI enemigosT;
   
    // Start is called before the first frame update
    void Start()
    {        
        gameOver = GameObject.Find("GameOver");
        youWin = GameObject.Find("YOU WON");
        youWin.SetActive(false);
        gameOver.SetActive(false);
        faltantesT.text = "Restantes 72";
        enemigosT.text = "Enemigos: " + enemigos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Derrota()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void EnemigosSpawn()
    {
        enemigos++;
        enemigosT.text = "Enemigos: " + enemigos;
    }

    public void EnemigosMuerte()
    {
        enemigos--;
        enemigosT.text = "Enemigos: " + enemigos;
    }

    public void Puntos()
    {        
        puntos++;
        faltantes--;
        Debug.Log(puntos + "    " + faltantes);

        puntosT.text = "Puntos: " + puntos;
        faltantesT.text = "Restantes " + faltantes;

        if(puntos == 72)
        {
            Victoria();
        }
    }

    public void Victoria()
    {
        youWin.SetActive(true);
        Time.timeScale = 0f;

    }
}
