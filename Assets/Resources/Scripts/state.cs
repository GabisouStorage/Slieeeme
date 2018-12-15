using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class state {

    public Rigidbody2D RB2D;


    public state()
    {


    }

    public void firstFrame()
    {

    }

    public void lastFrame()
    {


    }

    public void movimenta()
    {


    }

    public abstract void trataColisao(Collision2D col);

   

    public abstract void trataTrigger(Collider2D col);

    public abstract void exitThisState();


    

}
