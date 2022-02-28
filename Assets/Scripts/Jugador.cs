using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
 
    [SerializeField] float speed = 15; //Asi es privada y se puede modificar
    [SerializeField] GameObject bala;
    [SerializeField] GameObject balaCargada;
    private float modoDisparo = 1;
    private float minX, maxX, maxY, minY; //para limites
    private bool listo = false;
    private float tiempoAbajo, tiempoArriba, tiempoOprimido = 0;
    private float tiempoDisparoCargado = 3.0f;
    [SerializeField] float cadenciaDisparo = 1;
    private float proximoDisparo = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //llamo a la camara
        Vector2 esquinaInferiorIzquierda = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // transforma mundo de viewport al mundo del juego
        minX = esquinaInferiorIzquierda.x;
        minY = esquinaInferiorIzquierda.y;
        Vector2 esquinaSuperiorDerecha = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // transforma mundo de viewport al mundo del juego
        maxX = esquinaSuperiorDerecha.x;
        maxY = esquinaSuperiorDerecha.y;
    }

    // Update is called once per frame
    void Update()
    {

        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(dirH * speed * Time.deltaTime, dirV * speed * Time.deltaTime));  // divide los frame por el segundo digamos 100 frames por segundo, tiempo entre un frame y el otro
                                                                                                         //ahora independiente del frame para esto sirve el time delta time
                                                                                                         //get axis tiene una sensibilidad

        // mathf recibe un valor y revisa que no se pase de un minimo y un maximo.

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX + ((GetComponent<Renderer>().bounds.size) / 2).x, maxX - ((GetComponent<Renderer>().bounds.size) / 2).x), Mathf.Clamp(transform.position.y, minY + ((GetComponent<Renderer>().bounds.size) / 2).x + 2.8f*maxY/2 , maxY - ((GetComponent<Renderer>().bounds.size) / 2).x));

        if(Input.GetKeyDown(KeyCode.M))
        {
            modoDisparo = modoDisparo * -1;
        }

        // parte disparo
        if (modoDisparo == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > proximoDisparo)
            {
                proximoDisparo= Time.time + cadenciaDisparo;
                Instantiate(bala, transform.position, transform.rotation);
            }
        }
        if (modoDisparo == -1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && listo == false)
            {
                tiempoOprimido = Time.time;
                tiempoOprimido = tiempoOprimido + tiempoDisparoCargado;
                listo = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (Time.time >= tiempoOprimido && listo == true)
                {
                    listo = false;
                    Instantiate(balaCargada, transform.position, transform.rotation);
                }
                else
                {
                    listo = false;
                }
            }
        }
    }
}
