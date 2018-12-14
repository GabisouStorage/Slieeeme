using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solido : state {

    

    GameObject player;
     
    Vector3 pontoTranfosrmacaoSolido;
    Vector3 pontoColisaoComObjetoQuebravel;

    public solido(GameObject player)
    {
        Debug.Log("CONSTRUIU SOLIDO");
        this.player = player;
        Debug.Log("RAYCAST");
        pontoTranfosrmacaoSolido = player.transform.position;

        Rigidbody2D RB2D = player.GetComponent<Rigidbody2D>();
        
    }


    public override void trataTrigger(Collider2D col)
    {
      
    }

    public override void exitThisState()
    {

    }

    public override void trataColisao(Collision2D col)
    {
        verificaColisaoInimigo(col);

        objetoQuebrar quebravel = col.collider.GetComponent<objetoQuebrar>();

        if (quebravel != null)
        {
            pontoColisaoComObjetoQuebravel = player.transform.position;
            verificaDistanciaColisao(pontoColisaoComObjetoQuebravel, pontoTranfosrmacaoSolido,quebravel);
        }

     
    }

    public void verificaDistanciaColisao(Vector3 pontoColisao, Vector3 pontoTransformacao,objetoQuebrar quebravel)
    {
        float distancia = (pontoTransformacao.y - pontoColisao.y);

        if (distancia > quebravel.alturaMinimaDeQuedaParaSerQuebrado)
        {
            quebravel.quebrar();
        }
        else
        {
            Debug.Log("NAO QUEBROU");
        }
}

    
    public void verificaColisaoInimigo(Collision2D col)
    {
        // o objeto que colidiu com o player
        GameObject objetoColisor = col.collider.gameObject;

        if (objetoColisor.name.Contains("enemy"))
        {
            // chama o metodo no state controller que indica a morte do player
            stateController.mortePlayer();

            Debug.Log("tratou certo");
        }

    }





}
