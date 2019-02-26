using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventiladorController : MonoBehaviour {

    public int forcaVento = 5;
    public bool estouSugando = false;

    

   
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            if ((stateController.estadoAtual is gasoso))
            {
                Collider2D colisor = collision.GetComponent<Collider2D>();
                Rigidbody2D RB2D = colisor.GetComponent<Rigidbody2D>();
                ventiladorTrabalhando(RB2D);

                RB2D.gravityScale = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        Rigidbody2D RB2D = gameObject.GetComponent<Rigidbody2D>();

        if (stateController.estadoAtual is gasoso)
        {
            RB2D.gravityScale = -1;
        }
 
    }


    public void ventiladorTrabalhando(Rigidbody2D RB2D)
    {
        if (estouSugando == true)
        {
            sugar(RB2D);
        }
        else
        {
            ventar(RB2D);
        }

    }

    public void ventar(Rigidbody2D RB2D)
    {
        // ATENTEM AO FATO DE QUE SUGAR EM UMA DIREÇAO E SENTIDO EQUIVALE A VENTAR
        // NA MESMA DIREÇAO E SENTIDO OPOSTO
        if (gameObject.tag.Contains("Cima"))
        {
            ventarPraCima(RB2D);
        }

        if (gameObject.tag.Contains("Baixo"))
        {
            
            ventarPraBaixo(RB2D);
        }

        if (gameObject.tag.Contains("Esquerda"))
        {
            ventarPraEsquerda(RB2D);
        }

        if (gameObject.tag.Contains("Direita"))
        {
           
            ventarPraDireita(RB2D);

        }
    }

    public void sugar(Rigidbody2D RB2D)
    {
        // ATENTEM AO FATO DE QUE SUGAR EM UMA DIREÇAO E SENTIDO EQUIVALE A VENTAR
        // NA MESMA DIREÇAO E SENTIDO OPOSTO

        if (gameObject.tag.Contains("Cima"))
        {
            ventarPraBaixo(RB2D);
        }

        if (gameObject.tag.Contains("Baixo"))
        {
            ventarPraCima(RB2D);
        }

        if (gameObject.tag.Contains("Esquerda"))
        {
            ventarPraDireita(RB2D);
        }

        if (gameObject.tag.Contains("Direita"))
        {
            ventarPraEsquerda(RB2D);
        }
    }


    public void ventarPraCima(Rigidbody2D RB2D)
    {
      

        RB2D.velocity = (new Vector2(0, 1 * forcaVento));
    }


    public void ventarPraBaixo(Rigidbody2D RB2D)
    {
 
        RB2D.velocity = (new Vector2(0,- 1 * forcaVento));


    }


    public void ventarPraDireita(Rigidbody2D RB2D)
    {
        RB2D.velocity = (new Vector2(1 * forcaVento,0));
    }


    public void ventarPraEsquerda(Rigidbody2D RB2D)
    {
        RB2D.AddForce(new Vector2(-1 * forcaVento, 0));
    }



}
