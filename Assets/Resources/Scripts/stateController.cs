using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateController : MonoBehaviour {

    public static  state estadoAtual;
    public static GameObject player;
    public static Rigidbody2D playerRB;
  

    private void Start()
    {
        solido inicialController = new solido();
        estadoAtual = inicialController;
        player = gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            enterSlime();
        }

        if (Input.GetKeyDown("s"))
        {
            enterSolido( );
        }

        if (Input.GetKeyDown("p"))
        {
            enterPlasma( );
        }

        if (Input.GetKeyDown("g"))
        {
            enterGasoso();
        }
    }

    public void exitCurrentState()
    {
        estadoAtual.lastFrame();
        estadoAtual = null;

        Debug.Log("SAIU DE ONDE ESTAVA");
    }

    public void enterSolido()
    {
        exitCurrentState();

        solido solidoController = new solido();
        estadoAtual = solidoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU SOLIDO");
    }

    public void enterSlime()
    {
        exitCurrentState();

        slime slimeController = new slime();
        estadoAtual = slimeController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU SLIME");

    }

    public void enterGasoso()
    {
        exitCurrentState();

        gasoso gasosoController = new gasoso(playerRB);
        estadoAtual = gasosoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU GASOSO");
    }

    public void enterPlasma()
    {
        exitCurrentState();

        plasma plasmaController = new plasma();
        estadoAtual = plasmaController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU PLASMA");
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        estadoAtual.trataColisao(col);

        Debug.Log("oncolisionEnter2d");
    }

    //CheckPoint
    void OnTriggerEnter2D(Collider2D col)
    {
        estadoAtual.trataTrigger(col);
    }

    public static void mortePlayer()
    {
        Destroy(player);
    }





}


 