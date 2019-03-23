using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomadaController : MonoBehaviour
{


    public GameObject player;

    public string entradaTomada = "baixo";

    public bool aguardandoOrdens = false;

    public int velocidade;


    public bool caminhoCima = false;
    public bool caminhoBaixo = false;
    public bool caminhoDireita = false;
    public bool caminhoEsquerda= false;

    //script novo de caminhada em circuitos associado ao player
    public novoCaminhada novocaminho;

    public Transform pontoInicial;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        novocaminho = player.GetComponent<novoCaminhada>();
    }




    public void entrar(GameObject player)
    {
        Debug.Log("entrou aqui");

        recebePlayer(player);
        transformaPlayerPlasma(player);
        player.transform.localPosition = new Vector3(0, 0, 0);
        aguardarOrdens();
        liberarPlayer(player);
    }

    private void Update()
    {
        if (aguardandoOrdens == true) { 

            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && caminhoCima == true)
            { 
               receberOrdens("cima");
            }

            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && caminhoEsquerda == true)
            {
                receberOrdens("esquerda");
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && caminhoBaixo == true)
            {
                receberOrdens("baixo");
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && caminhoDireita == true)
            {
                receberOrdens("direita");
            }

        }

    }




    public void aguardarOrdens()
    {
        aguardandoOrdens = true;
        stateController.pararSemBloquearMovimentacao();
    }

    public void receberOrdens(string opcao)
    {
        aguardandoOrdens = false;
        posicionaPlayer(player, opcao);
        liberarPlayer(player);
    }

    public void recebePlayer(GameObject player)
    {
        player.transform.parent = gameObject.transform;
        this.player = player;
       


    }

    public void liberarPlayer(GameObject player)
    {
        player.transform.parent = null;
        this.player = null;

        player.GetComponent<novoCaminhada>().pontoInicial = pontoInicial;

        player.GetComponent<novoCaminhada>().enabled = true;

    }



    public void transformaPlayerPlasma(GameObject player)
    {
        stateController sc = player.GetComponent<stateController>();
        sc.enterPlasma(this);

    }

    public void posicionaPlayer(GameObject player, string opcao)
    {
        if (opcao == "direita")
        {
            posicionaPlayerDireita(player);
        }

        if (opcao == "esquerda")
        {
            posicionaPlayerEsquerda(player);
        }

        if (opcao == "cima")
        {
            posicionaPlayerCima(player);
        }

        if (opcao == "baixo")
        {
            posicionaPlayerBaixo(player);
        }

    }

    public void posicionaPlayerDireita(GameObject player)
    {
        player.transform.localPosition = new Vector3(0.5f, 0f, 0);
        plasmaMovDireita();
    }


    public void posicionaPlayerEsquerda(GameObject player)
    {
        player.transform.localPosition = new Vector3(-0.5f, 0f, 0);
        plasmaMovEsquerda();
    }

    public void posicionaPlayerCima(GameObject player)
    {
        player.transform.localPosition = new Vector3(-0f, 0.5f, 0);
        plasmaMovCima();
    }


    public void posicionaPlayerBaixo(GameObject player)
    {
        player.transform.localPosition = new Vector3(-0f, -0.5f, 0);
        plasmaMovBaixo();
    }


    public void plasmaMovDireita()
    {
        Rigidbody2D RB2D = player.GetComponent<Rigidbody2D>();
        RB2D.velocity = new Vector3(1 * velocidade, 0, 0);
    }

    public void plasmaMovEsquerda()
    {
        Rigidbody2D RB2D = player.GetComponent<Rigidbody2D>();
        RB2D.velocity = new Vector3(-1 * velocidade, 0, 0);
    }

    public void plasmaMovCima()
    {
        Rigidbody2D RB2D = player.GetComponent<Rigidbody2D>();
        RB2D.velocity = new Vector3(0, 1 * velocidade, 0);
    }

    public void plasmaMovBaixo()
    {
        Rigidbody2D RB2D = player.GetComponent<Rigidbody2D>();
        RB2D.velocity = new Vector3(0, -1 * velocidade, 0);
    }

    public void plasmaPara()
    {
        stateController.pararSemBloquearMovimentacao();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("marcus pinho");
        
    }

}

