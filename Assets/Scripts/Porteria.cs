using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porteria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bola")
        {
            if (this.name == "Izquierda")
            {
                other.GetComponent<Bola>().reiniciarBola("Derecha");
            }
            else if (this.name == "Derecha")
            {
                other.GetComponent<Bola>().reiniciarBola("Izquierda");
            }
        }

        if (other.name == "RaquetaIzq"||other.name == "RaquetaDer")
        {
            
        }
    }
}
