using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaMove : MonoBehaviour {

    Rigidbody2D RB2D;



    private void Start()
    {
       
    }


    
   
    public void entrar(GameObject player)
    {
       
    }




    private void OnCollisionStay(Collision collision)
    {
        Collider collider = collision.collider;

        if (collider.tag == "plataformaMovel")
        {

            Debug.Log("PLATTTTTTTTTT");
        }

        Debug.Log("PLATTTTTTTTTT");
    }



}
