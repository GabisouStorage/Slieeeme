using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasoso : state {

    Transform trans;
    
	// Use this for initialization

        public gasoso( )
        {
        Debug.Log("CONTRUIU GASOSO");
        }
    

    void Update()
    {
        // Ignora Colisão com layer, modificar o número da layer desejada
        Physics2D.IgnoreLayerCollision(8, 9);
    }
   

    public override void trataTrigger(Collider2D col)
    {
        // armazena o transform do objeto com que o player colidiu
        trans = col.gameObject.transform;
    }

    public override void exitThisState()
    { 
    }

    public override void trataColisao(Collision2D col)
    {
        // o objeto que colidiu com o player
        GameObject objetoColisor = col.gameObject;

        if (objetoColisor.name.Contains("enemy"))
        {
            // chama o metodo no state controller que indica a morte do player
            stateController.mortePlayer();

            Debug.Log("tratou certo");
        }

    }
}
