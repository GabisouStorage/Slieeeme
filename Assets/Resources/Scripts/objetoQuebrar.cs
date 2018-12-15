using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoQuebrar : MonoBehaviour {

    public float alturaMinimaDeQuedaParaSerQuebrado;


    public void quebrar()
    {
        Destroy(gameObject);

    }

}
