using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    GameObject jugador;
     public NavMeshAgent agente;
    void Start()
    {
        jugador = GameObject.Find("Chomp");
        
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(jugador.transform.position);
    }
}
