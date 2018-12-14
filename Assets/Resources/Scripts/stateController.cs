using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateController : MonoBehaviour {

    public static  state estadoAtual;
    public static GameObject player;
    public static Rigidbody2D playerRB;
    public static  SpriteRenderer sr;
    public float g;
   
    private void Start()
    { 
        player = gameObject;
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        solido inicialController = new solido(player);
        estadoAtual = inicialController;
        playerRB.gravityScale = g;
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
            //enterPlasma(circuitoPai);
        }

        if (Input.GetKeyDown("g"))
        {
            enterGasoso();
        }
    }

    public void exitCurrentState()
    {
        estadoAtual.lastFrame();
        estadoAtual.exitThisState();
        estadoAtual = null;

        Debug.Log("SAIU DE ONDE ESTAVA");

        pararSemBloquearMovimentacao(playerRB);
    }

    public void enterSolido()
    {
        exitCurrentState();

        solido solidoController = new solido(player);
        estadoAtual = solidoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU SOLIDO");
       
        playerRB.gravityScale = (g * 1);
        Debug.Log(playerRB.gravityScale);
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
       
        playerRB.gravityScale = 0;
    }

    public void enterGasoso()
    {
        exitCurrentState();

        gasoso gasosoController = new gasoso();
        estadoAtual = gasosoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU GASOSO");
        
        playerRB.gravityScale = (g *-1);
        Debug.Log(playerRB.gravityScale);
        sr.color = Color.gray;
    }

    public void enterPlasma(tomadaController circuitoPai)
    {
        exitCurrentState();

        plasma plasmaController = new plasma(circuitoPai);
        estadoAtual = plasmaController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU PLASMA");
       
       
        playerRB.gravityScale = 0;
        sr.color = Color.blue;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        estadoAtual.trataColisao(col);

        Debug.Log("oncolisionEnter2d");
    }

    //CheckPoint
    int OnTriggerEnter2D(Collider2D col)
    {
        /*verifica se o objeto com que colidimos posssui o script tomadaController 
        ,se isso for verdade significa que colidimos com um trigger do tipo tomada, se nao
        , colidimos com um trigger de outro tipo
        */
        tomadaController tc = col.GetComponent<tomadaController>();
   
        if (tc != null) { 
            tc.entrar(gameObject);
            return 0;
        }

        lampadaController lc = col.GetComponent<lampadaController>();

        if(lc != null)
        {
            lc.entrar(gameObject);
            return 0;
        }



            estadoAtual.trataTrigger(col);
            return 0;
         
    }
    

    public static void mortePlayer()
    {
        Destroy(player);
    }

    public static void parar(Rigidbody2D RB2D)
    {
        RB2D.velocity = new Vector3(0, 0, 0);
        RB2D.angularVelocity = 0;
        movinetacao movimenta = stateController.player.GetComponent<movinetacao>();
        movimenta.enabled = false;
    }

    public static void pararSemBloquearMovimentacao(Rigidbody2D RB2D)
    {
        RB2D.velocity = new Vector3(0, 0, 0);
        RB2D.angularVelocity = 0;
    }



}


