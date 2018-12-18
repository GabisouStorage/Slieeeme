using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateController : MonoBehaviour {

    public static  state estadoAtual;
    public static GameObject player;
    public static Rigidbody2D playerRB;
    public static  SpriteRenderer sr;
    public float  aceleracaoqueda = 2;
    
    public bool autorizaMudancaSlime = false;
    public static bool isDead = false;
    public float velocidadeSubidaVertical;

    private bool changeSlime = false;
   
    private void Start()
    { 
        player = gameObject;
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        
        slime inicialController = new slime();

        SlimeBehaviour sb = gameObject.GetComponent<SlimeBehaviour>();
        //sb.meHabilitar();
        sb.IsActive = true;


        estadoAtual = inicialController;
       playerRB.gravityScale = 0;
         isDead = false;
}

    private void Update()
    {
        if (Input.GetKeyDown("l") && autorizaMudancaSlime == true)
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

        pararSemBloquearMovimentacao();
        liberaStateController();
        liberaMovimentacao();

        desabilitarSlimeBehaviour();


    }

    public void enterSolido()
    {
        exitCurrentState();

        playerRB.rotation = 0;

        solido solidoController = new solido(player);
        estadoAtual = solidoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU SOLIDO");

        Debug.Log(playerRB.gravityScale);
     //   sr.color = Color.red;

        pararSemBloquearMovimentacao();
        playerRB.gravityScale = aceleracaoqueda;
    }

    public void enterSlime()
    {


        SlimeBehaviour sb = gameObject.GetComponent<SlimeBehaviour>();

        if (changeSlime || sb.CanChange)
        { 
            exitCurrentState();

            slime slimeController = new slime();
            estadoAtual = slimeController;
            estadoAtual.firstFrame();

            Debug.Log("ENTROU SLIME");

        //  sr.color = Color.green;

            pararSemBloquearMovimentacao();
            playerRB.gravityScale = 0;

            habilitarSlimeBehaviour();
        }

    }

    public void enterGasoso()
    {
        exitCurrentState();

        playerRB.rotation = 0;

        gasoso gasosoController = new gasoso();
        estadoAtual = gasosoController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU GASOSO");
        
   
        Debug.Log(playerRB.gravityScale);
     //   sr.color = Color.gray;

        pararSemBloquearMovimentacao();
        playerRB.gravityScale = 0;
        playerRB.velocity = new Vector2(0, velocidadeSubidaVertical);

       
    }

    public void enterPlasma(tomadaController circuitoPai)
    {
        exitCurrentState();

        playerRB.rotation = 0;

        plasma plasmaController = new plasma(circuitoPai);
        estadoAtual = plasmaController;
        estadoAtual.firstFrame();

        Debug.Log("ENTROU PLASMA");
       
       
       
    //    sr.color = Color.blue;

        bloqueiaMovimentacao();
        bloqueiaStateController();

        pararSemBloquearMovimentacao();
        playerRB.gravityScale = 0;

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        estadoAtual.trataColisao(col);

        if (col.gameObject.tag == "trap")
        {
            Collider2D euMesmo = gameObject.GetComponent<Collider2D>();
            Collider2D outro = col.gameObject.GetComponent<Collider2D>();

            Physics2D.IgnoreCollision(euMesmo, outro);
        }

        Debug.Log("oncolisionEnter2d");
        if (col.gameObject.tag == "Gosma")
        {
            changeSlime = true;
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Gosma")
        {
            changeSlime = true;
            print(Time.time);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Gosma"){
            changeSlime = false;
        }
    }

    public void desabilitarSlimeBehaviour()
    {

        SlimeBehaviour sb = gameObject.GetComponent<SlimeBehaviour>();
        sb.meDesabilitar();
        //sb.IsActive = false;
    }


    public void habilitarSlimeBehaviour()
    {

      SlimeBehaviour sb = gameObject.GetComponent<SlimeBehaviour>();

        sb.meHabilitar();
        //sb.IsActive = true;
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
       // mov.enabled = false;

    }

    public static  void liberaMovimentacao()
    {
        movinetacao mov = player.GetComponent<movinetacao>();
        //mov.enabled = true;

    }


    public static void bloqueiaStateController()
    {
        stateController sc = player.GetComponent<stateController>();
        sc.enabled = false;
    }

     
}


