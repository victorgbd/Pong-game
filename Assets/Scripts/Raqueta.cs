using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ejevertical;
    public string ejehorizontal;
    public float velocidad = 30.0f;
    private void FixedUpdate()
    {
        
        float vy = Input.GetAxisRaw(ejevertical);
        float vx = Input.GetAxisRaw(ejehorizontal);
        
        
        if(name == "RaquetaDer"){
            if (transform.position.x < 1.5)
            {
                
                vx = 1;
                
            }
        }
        else if(name == "RaquetaIzq"){
            if (transform.position.x > -1.5)
            {
                vx = -1;
                
            }
            
        }
        
        GetComponent<Rigidbody2D>().velocity = new Vector2( vx * velocidad, velocidad * vy);
        
        
       
    }
}
