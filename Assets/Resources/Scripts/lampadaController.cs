using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampadaController : MonoBehaviour {

    public void entrar(GameObject player)
    {
    
        stateController.liberaStateController();
        stateController.liberaMovimentacao();

        stateController sc = player.GetComponent<stateController>();

        if (stateController.estadoAtual is plasma) { 

            if (this.tag == "transformaSolido")
        {
            sc.enterSolido();
               // player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        if (this.tag == "transformaSlime")
        {
            sc.enterSlime();
               // player.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

        if (this.tag == "transformaGasoso")
        {
            sc.enterGasoso();
              //  player.GetComponent<Rigidbody2D>().gravityScale = -1;
            }

         //desabilita o script nova caminhada relativo ao player que entra na lampada
            player.GetComponent<novoCaminhada>().enabled = false;
        

    }
    }

   


}
