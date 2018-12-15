using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : state {

	// Use this for initialization

    public slime( )
    {
        Debug.Log("CONSTRUIU SLIME");
         
    }



    public override void trataTrigger(Collider2D col)
    {


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
