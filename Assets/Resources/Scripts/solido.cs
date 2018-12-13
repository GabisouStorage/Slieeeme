using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solido :state {

    public static int pesoObjeto = 15;
    public int distanciaQuebra;

    RaycastHit2D atingido;

    GameObject player;

    [SerializeField]
    LayerMask breakable;

    Vector3 pontoTranfosrmacaoSolido;
    Vector3 pontoColisaoComObjetoQuebravel;

    public solido(GameObject player,int distanciaQuebra)
    {
        Debug.Log("CONSTRUIU SOLIDO");

        this.player = player;

        RaycastHit2D atingido = Physics2D.Raycast(player.transform.position, Vector2.down, distanciaQuebra,stateController.breakable);
        this.atingido = atingido;

        Debug.Log(atingido.distance);

        Debug.Log("RAYCAST");

        pontoTranfosrmacaoSolido = player.transform.position;





    }


    public override void trataTrigger(Collider2D col)
    { 
        // procura se o objeto com que colidimos possui o script Objeto Quebrar
        objetoQuebrar quebravel = col.GetComponent<objetoQuebrar>();

        if(quebravel != null)
        {
            // caso o objeto com que colidimos seja quebravel
            
            //modificar mecanismo de avaliaçao da quebra para fazer baseado na distancia a partir da qual o sólido cairá
            // guardar x e y da transformaçao e verificar na queda OU utilizar o raycast
        
        }

      //  Debug.Log("passou trigger");
    }

    public override void exitThisState()
    {
        
    }

    public override void trataColisao(Collision2D col) 
    {
        
      
        if (atingido.distance > distanciaQuebra)
        {
            Debug.Log("atingimos algo");
        }

        Debug.Log(atingido.distance);

        // o objeto que colidiu com o player
        GameObject objetoColisor = col.gameObject;

        if (objetoColisor.name.Contains("enemy"))
        {
            // chama o metodo no state controller que indica a morte do player
            stateController.mortePlayer();

            Debug.Log("tratou certo");
        }


        pontoColisaoComObjetoQuebravel = player.transform.position;

        verificaDistanciaColisao(pontoColisaoComObjetoQuebravel, pontoTranfosrmacaoSolido,col.collider);
    }
    
    public void verificaDistanciaColisao(Vector3 pontoColisao, Vector3 pontoTransformacao,Collider2D col)
    {
        float distancia = (pontoTransformacao.y - pontoColisao.y);

        if(distancia > distanciaQuebra)
        {

            Debug.Log("QUEBROU");
        }
        else
        {
            Debug.Log("NAO QUEBROU");
        }
    }

        Debug.Log(distancia);

        Debug.Log("QUEBROU");

        quebrarObjeto(col);

    }

    public void quebrarObjeto(Collider2D col)
    {
        objetoQuebrar quebra = col.GetComponent<objetoQuebrar>();

        if(quebra != null)
        {
            quebra.quebrar();
            Debug.Log("QUEBROU2");
        }


        Debug.Log("QUEBROU2");
    }



}
