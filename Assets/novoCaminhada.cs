using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novoCaminhada : MonoBehaviour
{

    //variavel que define se o plasma está aguardando ordens para prosseguir 
    public bool aguardandoOrdens = false;

    //variavel que guarda um transform que é o proprio plasma 
    public Transform euMesmo;

    //variavel que guarda o primeiro ponto do caminho
    public Transform pontoInicial;

    /*muitas vezes as funcoes de movimento sao imprecisas , por isso , definimos um epsilon
     * que representa o erro maximo que toleramos 
     */
    public float epsilon;

    //variavel que representa o ponto do caminho para o qual o plasma tá indo 
    public Transform proximo;

    //variavel que representa a velocidade do plasma
    public int velocidade = 10;

    public seletorDirecao sd;


     



    private void Start()
    {
        proximo = pontoInicial;

        seletorDirecao sd = gameObject.GetComponent<seletorDirecao>();

       


    }


    private void Update()
    {
        if (aguardandoOrdens == false)
        {
            // se o plsma nao estiver aguardando ordens

            if (testaChegada() == false)
            {
                //se o plsma nao estiver aguardando ordens e  se o plasma ainda nao chegou no ponto de destino , continue andando
                euMesmo.position = Vector3.MoveTowards(this.transform.position, proximo.position, velocidade * Time.deltaTime) * 1;
            }
            else
            {
               /*se o plsma nao estiver aguardando ordens , mas chegou ao ponto de destino 
                * ele deve passar a aguardar ordens
                */
                    esperarOrdens();          
            }

        }

        if (aguardandoOrdens == true)
        {

            //se o plasma estiver aguardando ordens

            if (opcaoUnica(proximo))
            {
                proximo = getProximo(proximo, "nao interessa");

                receberOrdens();           
            }
            else
            { 

                if (Input.GetKeyDown("w"))
                {
                    proximo = getProximo(proximo, "a");
                    receberOrdens();
 

                }


                
                if (Input.GetKeyDown("a"))
                {
                    proximo = getProximo(proximo, "a");
                    receberOrdens();

                }

                if (Input.GetKeyDown("s"))
                {
                    proximo = getProximo(proximo, "s");
                    receberOrdens();
                }

                if (Input.GetKeyDown("d"))
                {
                    proximo = getProximo(proximo, "d");
                    receberOrdens();
                }
                
            }
        }

    }










    


    public bool testaChegada()
    {
        // avalia se o player já chegou no próximo ponto do caminho

        if (Vector2.Distance(this.transform.position, proximo.position) < epsilon)
        {
            return true;
        }

        return false;
    }


 


    public Transform getProximo(Transform pontoAtual,string opcaoEscolhida = "Nao interessa")
    {
        /*dado o ponto atual onde o jogador se encontra e a opção de direçao 
         * escolhida pelo jogador , retorna o próximo ponto do trajeto
         */ 

        ponto p = pontoAtual.GetComponent<ponto>();

        Transform retorno;

        if (opcaoUnica(pontoAtual))
        {
            /*se só houver um ponto na lista de proximos pontos do ponto atual , pegue o primeiro (e unico) da lista de 
             * vizinhos , pra ser o próximo
             */

            retorno = p.proximo[0];
        }
        else
        {
            /*caso haja mais, de um ponto na lista de vizinhos , escolha 
             * algum dos vizinhos com base na opçao de direçao selecionada pelo jogador
             */
            if (decodificarOpcao(opcaoEscolhida, p.proximo.Length - 1) >= 0)
            {
                /* caso a opçao de direçao selecionada pelo jogador seja válida ,
                 * escolha como proximo ponto o vizinho associado a essa direçao
                 */

                retorno = p.proximo[p.indiceVizinhoAtual];
            }
            else
            {
                /* caso a opçao de direçao selecionada pelo jogador seja INválida ,
                * escolha como proximo ponto o próprio ponto onde voce está
                */
                retorno = pontoAtual;
            }
        }

        return retorno;

    }




    public void esperarOrdens()
    {
        aguardandoOrdens = true;
    }




    public void  receberOrdens()
    {
        aguardandoOrdens = false;
    }


    public int decodificarOpcao(string opcao,int UltimaPosicaoVetor)
    {
        /* retorna um valor positivo, caso a opçao selecionada pelo jogador seja válida 
         * e retorna um valor negativo , caso a opçao selecionada pelo jogador seja invalida 
         */ 



        int retornoPlanejado = -5;

        if(opcao == "w")
        {
            receberOrdens();
            retornoPlanejado = 0;
        }

        if (opcao == "d")
        {
            receberOrdens();
            retornoPlanejado = 1;
        }


        if (opcao == "s")
        {
            receberOrdens();
            retornoPlanejado = 2;
        }
        if (opcao == "a")
        {
            receberOrdens();
            retornoPlanejado = 3;
        }
 

        if(retornoPlanejado <= UltimaPosicaoVetor)
        {
            return retornoPlanejado;
        }

        return -1;



       
    }

   
    public bool opcaoUnica(Transform pontoAnalisado)
    {
        //verifica se o ponto analisado somente possui um ponto como proximo 

        if(pontoAnalisado.GetComponent<ponto>().proximo.Length == 1)
        {

            return true;
        }
        else
        {
            return false;
        }


    }


     



}
