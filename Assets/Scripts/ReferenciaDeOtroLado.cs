using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoboVida : MonoBehaviour
{
    private Object[] enemigos;
    private Enemigo1 elEnemigo;
    private float vidaActual;
    [SerializeField] string nombre;
    [SerializeField] Text texto;
    // Start is called before the first frame update
    void Start()
    {
        enemigos = (Enemigo1[])FindObjectsOfType<Enemigo1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigos.Length > 0)
        {
            for (var i = 0; i < enemigos.Length; i++)
            {
                if (enemigos[i].name.Equals(nombre))
                {
                    elEnemigo = (Enemigo1)enemigos[i];
                    vidaActual = elEnemigo.vida;
                }
            }

            texto.text = "" + vidaActual;
        }

    }
}
