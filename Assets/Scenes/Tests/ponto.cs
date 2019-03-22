////using System.Collections;
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

        //seleciona como vizinho atual o primeiro membro da lista de vizinhos 
        vizinhoAtual = proximo[0];
      

        /*caso o valor atual de intervalo do ponto seja 0 , defina como 10
         *(fizemos isso para que o GD ,nao tenha que ficar tendo o trabalho de setar o valor dessa variavel para os pontos que nao possuem vizinho)      
         */
         
        if(intervalo == 0)
        {
            intervalo = 10;
            trocavizinho();
        }


    }



    private void Update()
    {
        //contabiliza o tempo passado desde a ultima mudança de chavemento
        tempoDecorrido = tempoDecorrido + Time.deltaTime;

        if (tempoDecorrido > intervalo)
        {
            // quando o tempo decorrido desde a ultima mudança for maior que o intervalo definido , zere o tempo e troque o vizinho
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

    void desenhaLinhaVizinho(int i,float intervalo)
    {
        DrawLine(euMesmo.position,proximo[i].position,Color.black,intervalo);

    }




    void trocavizinho()
    {
        if (proximo.Length > 0)
        {       
            //executado caso o ponto possua vizinhos

            if ((indiceVizinhoAtual + 1) < (proximo.Length))
            {
                // caso o proximo vizinho exista (nao estoure o tamanho do vetor de vizinhos)
                indiceVizinhoAtual++;
            }
            else
            {
                // caso o proximo vizinho nao exista (estoure o tamanho do vetor de vizinhos)
                indiceVizinhoAtual = 0;
            }

          
            //desenha o caminho para o próximo vizinho 
            desenhaLinhaVizinho(indiceVizinhoAtual,intervalo);

            // DrawLine(gameObject.transform.position, proximo[indiceVizinhoAtual].position, Color.red, intervalo);

        }

    }








}
