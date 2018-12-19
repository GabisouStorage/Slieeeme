using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour {


    public bool ativo;
    public float tempoDecorrido;
    public float tempoEspera;
    public float tempoTiro;


    private void OnTriggerStay2D(Collider2D collision)
    {
 


        if ((collision.GetComponent<Collider2D>().tag == "Player") && (ativo == true))
        {
            stateController.mortePlayer();
        }
    }


    private void Update()
    {
        if (ativo == false) { 

        if (tempoDecorrido < tempoEspera)
        {
            tempoDecorrido += Time.deltaTime;

        }
        else
        {
            tempoDecorrido = 0;
            ativaLaser();
        }
    }

        if (ativo == true)
        {

            if (tempoDecorrido < tempoTiro)
            {
                tempoDecorrido += Time.deltaTime;

            }
            else
            {
                tempoDecorrido = 0;
                desativaLaser();
            }
        }



    }



    void ativaLaser()
    {
        ativo = true;
        this.GetComponent<SpriteRenderer>().color = Color.red;
    }


    void desativaLaser()
    {
        ativo = false;
        this.GetComponent<SpriteRenderer>().color = Color.blue;

    }



}
