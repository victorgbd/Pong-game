using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    //public static Bola bola;
    //Contadores de goles
    public int golesIzquierda = 0;
    public int golesDerecha = 0;
//Cajas de texto de los contadores
    public Text contadorIzquierda;
    public Text contadorDerecha;
    public Text FinJuego;
    AudioSource fuente;

    public AudioClip audioGol, audioRebote, audioRaqueta,audioVictoria;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right*velocidad;
        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
        fuente = GetComponent<AudioSource>();
        tiempo = 0.0f;
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "RaquetaIzq")
        {
            int x = 1;

            int y = direccionY(transform.position,
                other.transform.position);

            Vector2 direccion = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            fuente.clip = audioRaqueta;
            fuente.Play();

        }
        if (other.gameObject.name == "RaquetaDer")
        {
            int x = -1;
            int y = direccionY(transform.position,
                other.transform.position);
            Vector2 direccion = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            fuente.clip = audioRaqueta;
            fuente.Play();
        }

        if (other.gameObject.name == "Arriba" || other.gameObject.name == "Abajo")
        {
            fuente.clip = audioRebote;
            fuente.Play();
        }
    }
    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public void reiniciarBola(string direccion)
    {
        transform.position = Vector2.zero;
        fuente.clip = audioGol;
        fuente.Play();
        //velocidad = 30.0f;
        if (direccion == "Derecha")
        {
            velocidad = velocidad + 5.0f;
            golesDerecha++;
            if (ModoJuego.modoJuego.golesFlag)
            {
                if (golesDerecha == 5)
                {
                    FinJuego.text = "Fin del juego\nGana Jugador Derecho\nPreciona P o Click para reiniciar";
                    FinJuego.gameObject.SetActive(true);
                    //Time.timeScale = 0f;
                    
                    fuente.clip = audioVictoria;
                    fuente.Play();
                    finFlag = true;
                }
            }
            contadorDerecha.text = golesDerecha.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.right*velocidad;
        }
        else if (direccion == "Izquierda")
        {
            velocidad = velocidad + 5.0f;
            golesIzquierda++;
            if (ModoJuego.modoJuego.golesFlag)
            {
                if (golesIzquierda == 5)
                {
                    FinJuego.text = "Fin del juego\nGana Jugador Izquierdo\nPreciona P o Click para reiniciar";
                    FinJuego.gameObject.SetActive(true);
                    //Time.timeScale = 0f;
                    
                    fuente.clip = audioVictoria;
                    fuente.Play();
                    finFlag = true;
                }
            }
            contadorIzquierda.text = golesIzquierda.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
        }

        
        
    }

    private bool finFlag=false;

    private float tiempo;
    // Update is called once per frame
    void Update()
    {
        //velocidad = velocidad + 0.01f;
        if (finFlag)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Inicio");
                Time.timeScale = 1f;
                finFlag = false;
            }
        }

        tiempo += Time.deltaTime;
        if (ModoJuego.modoJuego.tiempoFlag)
        {
            if (tiempo >= 180)
            {
                if (golesIzquierda>golesDerecha)
                {
                    FinJuego.text = "Fin del juego\nGana Jugador Izquierdo\nPreciona P o Click para reiniciar";
                    FinJuego.gameObject.SetActive(true);
                    fuente.clip = audioVictoria;
                    fuente.Play();
                    Time.timeScale = 0f;
                    finFlag = true;
                }
                else if (golesDerecha>golesIzquierda)
                {
                    FinJuego.text = "Fin del juego\nGana Jugador Derecho\nPreciona P o Click para reiniciar";
                    FinJuego.gameObject.SetActive(true);
                    fuente.clip = audioVictoria;
                    fuente.Play();
                    Time.timeScale = 0f;
                    finFlag = true;
                }else if (golesDerecha == golesIzquierda)
                {
                    FinJuego.text = "Fin del juego\nEmpate\nPreciona P o Click para reiniciar";
                    FinJuego.gameObject.SetActive(true);
                    fuente.clip = audioVictoria;
                    fuente.Play();
                    Time.timeScale = 0f;
                    finFlag = true;
                }

                tiempo = 0.0f;

            }
        }
        
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Inicio");
            Time.timeScale = 1f;
        }
        
    }

    public float velocidad = 30.0f;
    
}
