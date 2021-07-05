using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModoJuego : MonoBehaviour
{
    public static ModoJuego modoJuego;
    public bool tiempoFlag = false;
    public bool golesFlag = false;

    private void Awake()
    {
        if (modoJuego == null)
        {
            modoJuego = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (modoJuego != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Inicio")
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                tiempoFlag = true;
                golesFlag = false;
            }
            else if(Input.GetKeyDown(KeyCode.G))
            {
                golesFlag = true;
                tiempoFlag = false;
            }
        }
        
    }
}
