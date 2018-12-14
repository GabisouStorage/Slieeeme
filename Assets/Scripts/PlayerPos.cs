using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
                                                //COLOCAR NO PERSONAGEM COM TAG DE "Player" para salvar a posição
public class PlayerPos : MonoBehaviour {

    private GameMaster gm;
    private bool isDead;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    //IDEIA DE PARA QUANDO A VARIAVEL QUE DEVE SER CHAMADA NO SCRIPT FOR TRUE DE O PLAYER TER MORRIDO, ELE RECEBE A POSIÇÃO DO ULTIMO CHECKPOINT
    void Update()
    {
       if(isDead = true)
        {
            transform.position = gm.lastCheckPointPos;
        }
    }
}
