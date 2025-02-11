using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    GameObject jugador;
    GameObject centro;
     public NavMeshAgent agente;
    int comecocos = 0;
    void Start()
    {
        jugador = GameObject.Find("Chomp");
        centro = GameObject.Find("Centro");
        agente = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(comecocos == 0)
        {
            agente.SetDestination(jugador.transform.position);
        }

        else if (comecocos == 1)
        {
            agente.SetDestination(centro.transform.position);
        }
    }

    public void Comecocos()
    {
        Debug.Log(comecocos);
        comecocos = 1;
    }

    public void Comecocosoff()
    {
        comecocos = 0;
    }
}
