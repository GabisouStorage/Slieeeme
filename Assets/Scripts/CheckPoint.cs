using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                                //COLOCAR NO GAMEOBJECT CHECKPOINT
public class Checkpoint : MonoBehaviour {

    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    //Função para o gm que tem a tag de gamemaster receber a posição atual do checkpoint
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
        }
    }
}
