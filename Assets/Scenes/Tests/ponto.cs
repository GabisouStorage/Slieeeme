﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponto : MonoBehaviour
{

    //vetor que armazena os nós vizinhos ao meu ponto
    public Transform[] proximo;

    //transform do proprio nó que carrega esse script
    public Transform euMesmo;

    
    // intervalo de tempo para que a chave mude
    public float intervalo;

    //tempo decorrido desde a ultima mudança de chave
    public float tempoDecorrido;
 

    //vizinho selecionado atual
    public Transform vizinhoAtual;
    //indice do vizinho selecionado atual
    public int indiceVizinhoAtual = 0;


    // Start is called before the first frame update
    void Start()
    {

        euMesmo = this.gameObject.transform;

        for(int i = 0; i < proximo.Length; i++)
        {
           // desenhaLinhaVizinho(i);
        }

        
        vizinhoAtual = proximo[0];

    }



    private void Update()
    {
        tempoDecorrido = tempoDecorrido + Time.deltaTime;

        if (tempoDecorrido > intervalo)
        {
            tempoDecorrido = 0;

            trocavizinho();

        }
    }










    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();// instanciar prefab linha
        myLine.transform.position = start;//
        myLine.AddComponent<LineRenderer>();//
        LineRenderer lr = myLine.GetComponent<LineRenderer>();//
        lr.material = new Material(Shader.Find("Standard"));//
        lr.SetColors(color, color);//
        lr.SetWidth(0.1f, 0.1f);//
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        Destroy(myLine, duration);
    }

    void desenhaLinhaVizinho(int i)
    {
        DrawLine(euMesmo.position,proximo[i].position,Color.black,5000);

    }




    void trocavizinho()
    {
        if (proximo.Length > 0)
        {
            DrawLine(gameObject.transform.position, proximo[indiceVizinhoAtual].position, Color.red, 6);

            if ((indiceVizinhoAtual + 1) < (proximo.Length))
            {
                indiceVizinhoAtual++;
            }
            else
            {
                indiceVizinhoAtual = 0;

            }

        }

    }








}
