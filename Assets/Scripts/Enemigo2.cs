using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo2 : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 2; //Asi es privada y se puede modificar
    private float minX, maxX; //para limites
    public float vida = 10;
    [SerializeField] Text texto;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //llamo a la camara
        Vector2 esquinaInferiorIzquierda = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // transforma mundo de viewport al mundo del juego
        minX = esquinaInferiorIzquierda.x;
        Vector2 esquinaSuperiorDerecha = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // transforma mundo de viewport al mundo del juego
        maxX = esquinaSuperiorDerecha.x;
        texto.text = "" + vida;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() // tiene la frecuencia del sistema de la fisica // manejo algo de la fisica
    {
        //definir limites
        //cambiar velocidad segun limites
        // buena practica cuando se cambian cosas del rigidbody; cuando las cosas constantes se deben decir en cada frame cuando se usa rigidbody
        Vector2 posicionEnemigo = transform.position;
        if (posicionEnemigo.x <= minX + ((GetComponent<Renderer>().bounds.size) / 2).x)
        {
            speed = speed * -1;
        }
        if (posicionEnemigo.x >= maxX - ((GetComponent<Renderer>().bounds.size) / 2).x)
        {
            speed = speed * -1;
        }
        rb.velocity = new Vector2(speed, rb.velocity.y); // para no tocar velocidad en y
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Bala(Clone)"))
        {
            vida = vida - 1;
            Debug.Log("vida actual" + this.gameObject.name + "=" + vida);
            texto.text = "" + vida;
        }
        if (collision.gameObject.name.Equals("BalaCargada(Clone)"))
        {
            vida = 0;
            Debug.Log("vida actual" + this.gameObject.name + "=" + vida);
            texto.text = "" + vida;
        }
        if(vida == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
