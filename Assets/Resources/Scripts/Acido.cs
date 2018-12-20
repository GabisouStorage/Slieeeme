using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acido : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.GetComponent<Collider2D>().tag == "Player") && stateController.estadoAtual is solido)
        {
            stateController.mortePlayer();
            print("MORREU SOLIDO");
        }
    }
}
