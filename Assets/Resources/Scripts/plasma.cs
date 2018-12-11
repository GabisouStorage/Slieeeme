using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasma : state {


    int moduloForca = 5;
    
    public  Rigidbody2D euMesmo;
    public tomadaController circuitoPai;

    public plasma(tomadaController circuitoPai)
    {

        Debug.Log("CONSRUIU PLASMA");
        this.circuitoPai = circuitoPai;

        parar();
    }
 
    public   override void  trataTrigger(Collider2D col)
    {
        if (col.tag.Contains("curva"))
        {
            Debug.Log("olha a curva");

            if (col.tag.Contains("Direita"))
            {
                Debug.Log("Direita");
                circuitoPai.plasmaMovDireita();

            }

            if (col.tag.Contains("Esquerda"))
            {
                Debug.Log("Esquerda");
                circuitoPai.plasmaMovEsquerda();

            }

            if (col.tag.Contains("Cima"))
            {
                Debug.Log("Cima");
                circuitoPai.plasmaMovCima();

            }

            if (col.tag.Contains("Baixo"))
            {
                Debug.Log("Baixo");
                circuitoPai.plasmaMovBaixo();

            }
        }

    }

    void Update()
    {


      
    }

    public void parar()
    {
        Rigidbody2D RB2D = stateController.player.GetComponent<Rigidbody2D>();
        RB2D.velocity = new Vector3(0, 0, 0);
        RB2D.angularVelocity = 0;
        movinetacao movimenta = stateController.player.GetComponent<movinetacao>();
        movimenta.enabled = false;
    }

    public override void exitThisState()
    {
        movinetacao movimenta = stateController.player.GetComponent<movinetacao>();
        movimenta.enabled = true;

    }

}
