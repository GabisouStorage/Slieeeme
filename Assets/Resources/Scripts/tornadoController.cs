using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornadoController : MonoBehaviour {


 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.GetComponent<Collider2D>().tag == "Player") && stateController.estadoAtual is gasoso)
        {
            stateController.mortePlayer();
        }
    }

     

     
}
