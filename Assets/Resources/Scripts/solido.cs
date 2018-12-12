using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solido :state {

    public static int pesoObjeto = 15;

    public solido( )
    {
        Debug.Log("CONSTRUIU SOLIDO");
        stateController.cair();
        
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
            quebravel.colidiramComigo(pesoObjeto);

            Debug.Log("passou triggerCerto");
        }

      //  Debug.Log("passou trigger");
    }

    public override void exitThisState()
    {
        
    }

    

}
