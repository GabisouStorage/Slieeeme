using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class state {

 

    public void firstFrame()
    {

    }

    public void lastFrame()
    {


    }

    public void movimenta()
    {


    }

    public  void trataColisao(Collision2D col)
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

   

    public abstract void trataTrigger(Collider2D col);
    

}
