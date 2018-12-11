using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateController : MonoBehaviour {

    public static  state estadoAtual;
    public static GameObject player;
    public static Rigidbody2D playerRB;
    public static  SpriteRenderer sr;
  

    private void Start()
    {
        solido inicialController = new solido();
        estadoAtual = inicialController;
        player = gameObject;
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
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

        sr.color = Color.red;
    }

    public void enterSlime()
    {
        exitCurrentState();

        slime slimeController = new slime();
        estadoAtual = slimeController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU SLIME");

        sr.color = Color.green;
    }

    public void enterGasoso()
    {
        exitCurrentState();

        gasoso gasosoController = new gasoso(playerRB);
        estadoAtual = gasosoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU GASOSO");

        sr.color = Color.gray;
    }

    public void enterPlasma()
    {
        exitCurrentState();

        plasma plasmaController = new plasma();
        estadoAtual = plasmaController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU PLASMA");

        sr.color = Color.blue;
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


 