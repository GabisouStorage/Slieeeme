﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seletorDirecao : MonoBehaviour
{
    //script geral do nó , pertencente ao nó que contem esse seletor de direção
    ponto ponto;

    public float intervalo;
    public float tempoDecorrido;

    // lista de vizinhos, obtida a partir do script geral do nó
    public Transform[] vizinhos;

    //vizinho selecionado atual
    public Transform vizinhoAtual;
    public int indiceVizinhoAtual = 0;


    // Start is called before the first frame update
    void Start()
    {
        ponto = this.GetComponent<ponto>();

        vizinhos = ponto.proximo;
        vizinhoAtual = vizinhos[0];

    }

    // Update is called once per frame
    void Update()
    {
        tempoDecorrido = tempoDecorrido + Time.deltaTime;

        if(tempoDecorrido > intervalo)
        {
            tempoDecorrido = 0;

            trocavizinho();

        }

    }


    void trocavizinho()
    {
        if((indiceVizinhoAtual +1) < (vizinhos.Length))
        {
            indiceVizinhoAtual++;
        }
        else
        {
            indiceVizinhoAtual = 0;

        }

        vizinhoAtual = vizinhos[indiceVizinhoAtual];

        DrawLine(gameObject.transform.position, vizinhoAtual.position, Color.red, 6);

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







}
