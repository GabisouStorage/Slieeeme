using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilSlimeController : MonoBehaviour {


    
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") 
        {
             if (stateController.estadoAtual is slime) { 
                matarPlayer();
                morrer();
             }

            if (stateController.estadoAtual is solido)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.collider);
            }

            if (stateController.estadoAtual is gasoso)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.collider);
            }
        }
    }




    public void morrer()
    {
        Destroy(gameObject);

    }

    public void matarPlayer()
    {
        stateController.mortePlayer();

    }

 

}
