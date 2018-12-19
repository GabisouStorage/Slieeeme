using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidController : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.collider.tag == "Player") && stateController.estadoAtual is solido)
        {

            stateController.mortePlayer();

        }




    }






}
