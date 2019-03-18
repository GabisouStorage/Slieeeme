using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminhada : MonoBehaviour
{
    // vetor de transforms que representa o caminho que o plasma deverá seguir
    public Transform[] caminho;

    // rigidibody que representa o próprio plasma 
    public Rigidbody2D euMesmo;

    // transform que representa o ponto do caminho pra onde o plasma tá se dirigindo
    Transform proximo;

    //posicao no caminho , do ponto pra onde plasma tá se dirigindo 
    int posicao = 0;

    /*algumas funçoes de distancia no unity sao imprecisas , por isso definimos uma variavel 
     * epsilon que representa o nosso erro tolerável */
    public float epsilon;

    void Start()
    {
        proximo = caminho[posicao];
    }


    void Update()
    {
        if (testaChegada() == false) { 

            //se o plasma ainda nao chegou no ponto de destino , continue andando
            euMesmo.position = Vector3.MoveTowards(this.transform.position, proximo.position, 1) * 1;
        }
        else 
        {
            //se o plasma chegou no ponto de destino , mude o destino

            if((posicao + 1) < (caminho.Length))
            {
                // se o proximo ponto ainda está no caminho (nao ultrapassa o final do caminho) , vá para ele
                posicao++;             
            }
            else
            {
                // se o proximo ponto , ultrapassa o final do caminho , vá para o inicio do caminho
               // posicao = 0;
            }

            proximo = caminho[posicao];
        }

    }

    public bool testaChegada()
    {
        // avalia se o player já chegou no próximo ponto do caminho

        if(Vector2.Distance(this.transform.position,proximo.position) < epsilon)
        {
            return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("marcus pinho");

    }







}
