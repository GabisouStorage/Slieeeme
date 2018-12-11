using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : state {

	// Use this for initialization


    public slime()
    {
        Debug.Log("CONSTRUIU SLIME");
          
    }



    public override void trataTrigger(Collider2D col)
    {


    }

    public override void exitThisState()
    {
        movinetacao movimenta = stateController.player.GetComponent<movinetacao>();
        movimenta.enabled = true;

    }
}
