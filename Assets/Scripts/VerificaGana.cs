using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerificaGana : MonoBehaviour
{
    private Object[] textos;
    private Text eltexto;
    private string[] datos = new string[9];
    // Start is called before the first frame update
    void Start()
    {
        textos = (Text[])FindObjectsOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textos.Length > 0)
        {
            for (var i = 0; i < textos.Length; i++)
            {
                eltexto = (Text)textos[i];
                datos[i] = eltexto.text;
                //Debug.Log(eltexto.text);
            }
            //Debug.Log(datos[1]);
            if (datos[0].Equals("0") && datos[2].Equals("0") && datos[3].Equals("0") && datos[4].Equals("0") && datos[5].Equals("0") && datos[6].Equals("0") && datos[7].Equals("0") && datos[8].Equals("0") )
            {
                Text victoria = (Text)textos[1];
                victoria.text = "VICTORIA!!!";
                Debug.Log(victoria.text);
            }
        }

    }
}
