using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float velBala = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.name.Equals("Bala(Clone)"))
        {
            Debug.Log(collision.gameObject.name);
            Destroy(this.gameObject);
        }

    }
    private void FixedUpdate() // tiene la frecuencia del sistema de la fisica // manejo algo de la fisica
    {
        //definir limites
        //cambiar velocidad segun limites
        // buena practica cuando se cambian cosas del rigidbody; cuando las cosas constantes se deben decir en cada frame cuando se usa rigidbody
        rb.gravityScale = rb.gravityScale * (velBala);
    }
}
