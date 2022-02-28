using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorClase : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 entrada;

    public float vel;
    [SerializeField] float speed = 15; //Asi es privada y se puede modificar
    [SerializeField] GameObject bala;
    float minX, maxX, maxY, minY; //para limites

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// si lo muevo por rigid
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
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate( new Vector2(0.001f , 0)); // 0.1f es float
        } */
        // parte realizada en clase


        //parte con rigid body
        //entrada.x = Input.GetAxis("Horizontal"); // la parte de input.getaxis = float
        //entrada.y = Input.GetAxis("Vertical"); // control d me copia la lina en l aque estoy

        // lo que hizo el profe en clase

        float dirH= Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(dirH*speed*Time.deltaTime, dirV*speed*Time.deltaTime));  // divide los frame por el segundo digamos 100 frames por segundo, tiempo entre un frame y el otro
                                                                                                 //ahora independiente del frame para esto sirve el time delta time
                                                                                                 //get axis tiene una sensibilidad

        // mathf recibe un valor y revisa que no se pase de un minimo y un maximo.

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX+ ((GetComponent<Renderer>().bounds.size) / 2).x, maxX-((GetComponent<Renderer>().bounds.size)/2).x), Mathf.Clamp(transform.position.y, minY+ ((GetComponent<Renderer>().bounds.size) / 2).x, maxY- ((GetComponent<Renderer>().bounds.size) / 2).x));


        // parte disparo

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, transform.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        //rb.velocity = entrada * vel * Time.fixedDeltaTime;
    }
}
