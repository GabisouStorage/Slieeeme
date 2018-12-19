using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botaoController : MonoBehaviour {

    public bool estouPressionado = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        pressionarBotao();
    }


    public void pressionarBotao()
    {
        estouPressionado = true;

    }






}
