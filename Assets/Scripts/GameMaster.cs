using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                                                    //COLOCAR NO GAMEOBJECT VAZIO COM A TAG DE "GM" E NOME GAME MASTER
public class GameMaster : MonoBehaviour {

    private static GameMaster instance;
    public Vector2 lastCheckPointPos;

    //Função para não permanecer vários GameObject de GameMaster ao salvar um novo checkpoint
    void Awake()
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);

        }
    }
}
