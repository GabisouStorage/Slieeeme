using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateController : MonoBehaviour {

    public static  state estadoAtual;
    public static GameObject player;
    public static Rigidbody2D playerRB;
    public static  SpriteRenderer sr;
    public float  g = 2;
    public bool autorizaMudancaSlime = false;
    public static bool isDead = false;
   
    private void Start()
    { 
        player = gameObject;
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        solido inicialController = new solido(player);
        estadoAtual = inicialController;
       playerRB.gravityScale = g;
         isDead = false;
}

    private void Update()
    {
        if (Input.GetKeyDown("1") && autorizaMudancaSlime == true)
        {
            enterSlime();
        }

        if (Input.GetKeyDown("2"))
        {
            enterSolido( );
        }

        if (Input.GetKeyDown("3"))
        {
            //enterPlasma(circuitoPai);
        }

        if (Input.GetKeyDown("4"))
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

        pararSemBloquearMovimentacao();
        liberaStateController();
        liberaMovimentacao();
    }

    public void enterSolido()
    {
        exitCurrentState();

        solido solidoController = new solido(player);
        estadoAtual = solidoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU SOLIDO");

        Debug.Log(playerRB.gravityScale);
        sr.color = Color.red;

        pararSemBloquearMovimentacao();
        playerRB.gravityScale = g;
    }

    public void enterSlime()
    {
        exitCurrentState();

        slime slimeController = new slime();
        estadoAtual = slimeController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU SLIME");

        sr.color = Color.green;

        pararSemBloquearMovimentacao();
        playerRB.gravityScale = 0;
    }

    public void enterGasoso()
    {
        exitCurrentState();

        gasoso gasosoController = new gasoso();
        estadoAtual = gasosoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU GASOSO");
        
   
        Debug.Log(playerRB.gravityScale);
        sr.color = Color.gray;

        pararSemBloquearMovimentacao();
        playerRB.gravityScale = (g * -1);

       
    }

    public void enterPlasma(tomadaController circuitoPai)
    {
        exitCurrentState();

        plasma plasmaController = new plasma(circuitoPai);
        estadoAtual = plasmaController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU PLASMA");
       
       
       
        sr.color = Color.blue;

        bloqueiaMovimentacao();
        bloqueiaStateController();

        pararSemBloquearMovimentacao();
        playerRB.gravityScale = 0;

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        estadoAtual.trataColisao(col);

        Debug.Log("oncolisionEnter2d");


        if (col.collider.tag == "gosma")
        {
            autorizaMudancaSlime = true;

        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "gosma")
        {
            autorizaMudancaSlime = false;

        }

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

        plataformaMove pm = col.GetComponent<plataformaMove>();

        if(pm != null)
        {
            pm.entrar(gameObject);
            return 0;
        }

            estadoAtual.trataTrigger(col);
            return 0;
         
    }
    

    public static void mortePlayer()
    {
        Destroy(player);
        stateController.isDead = true;
    }

    

    public static void pararSemBloquearMovimentacao()
    {
        playerRB.velocity = new Vector3(0, 0, 0);
        playerRB.angularVelocity = 0;
    }


    public static void liberaStateController()
    {
        stateController sc = player.GetComponent<stateController>();
        sc.enabled = true;

    }


    public static void bloqueiaMovimentacao()
    {
        movinetacao mov = player.GetComponent<movinetacao>();
        mov.enabled = false;

    }

    public static  void liberaMovimentacao()
    {
        movinetacao mov = player.GetComponent<movinetacao>();
        mov.enabled = true;

    }


    public static void bloqueiaStateController()
    {
        stateController sc = player.GetComponent<stateController>();
        sc.enabled = false;
    }

     
}


