using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NavJugador : MonoBehaviour
{
    float velocidad;
    GameObject GameobjectwithCharacterController;
    CharacterController controller ;
    public GameManager gameManager;

    void Start()
    {
        controller = this.GetComponent<CharacterController>();
         velocidad = 3.0f;
    }
    void Update()
    {
    }
    void FixedUpdate()
    {

        //Capturo el movimiento en los ejes
        float movimientoV = Input.GetAxis("Horizontal") * -1;
        float movimientoH = Input.GetAxis("Vertical");

        Vector3 anguloTeclas = new Vector3(movimientoH, 0f, movimientoV);
        
        transform.Translate(anguloTeclas * velocidad * Time.deltaTime, Space.World);

        //Genero el vector de movimiento
        //Muevo el jugador
        //transform.position += anguloTeclas * velocidad * Time.deltaTime;
        controller.Move(anguloTeclas * velocidad * Time.deltaTime);
        if (anguloTeclas != null && anguloTeclas != Vector3.zero)
        {
            transform.forward = anguloTeclas * 1;
            transform.rotation = Quaternion.LookRotation(anguloTeclas);
        }
    }
     void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto colisionado es la esfera
        if (other.CompareTag("Esfera"))
        {
            // Destruye todos los objetos con la etiqueta "Enemigo"
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemigo in enemigos)
            {
                Destroy(enemigo);
            }

            // Opcional: Destruye la esfera después de la colisión
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
            gameManager.Derrota();
        }

        if (other.CompareTag("Puntos"))
        {
            gameManager.Puntos();
            Destroy(other.gameObject);
        }
    }

}