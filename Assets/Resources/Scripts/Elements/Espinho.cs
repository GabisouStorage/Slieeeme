using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
        if ((other.gameObject.GetComponent<Collider2D>().tag == "Player") && stateController.estadoAtual is slime)
        {
            stateController.mortePlayer();
            print("MORREU SLIME");
        }
	}
}
