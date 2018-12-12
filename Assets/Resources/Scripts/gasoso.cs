using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasoso : state {

    Transform trans;
    
	// Use this for initialization

        public gasoso( )
        {
        Debug.Log("CONTRUIU GASOSO");

        stateController.subir();
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
