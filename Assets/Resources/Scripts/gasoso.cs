using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasoso : state {

    Transform trans;
    
	// Use this for initialization

        public gasoso(Rigidbody2D playerRb)
        {

        /* na construçao do estado gasoso
         * analisamos se a gravidade esta pra baixo ou pra cima 
         * e com isso , invertemos a gravidade usando o componente rigidBody do player 
         * que está armazenado na classe state controller
         */

        Debug.Log("CONTRUIU GASOSO");

        if (playerRb.gravityScale > 0)
        {
            playerRb.gravityScale = -1;
        }
        else
        {
            playerRb.gravityScale = 1;
        }

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

}
