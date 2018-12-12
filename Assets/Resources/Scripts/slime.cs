using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : state {

	// Use this for initialization

    public slime( )
    {
        Debug.Log("CONSTRUIU SLIME");
        stateController.gravidadeZero();
    }



    public override void trataTrigger(Collider2D col)
    {


    }

    public override void exitThisState()
    {
       

    }
}
