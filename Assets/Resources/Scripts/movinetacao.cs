using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movinetacao : MonoBehaviour {

   public int moduloForca = 5;
   public  Rigidbody2D euMesmo;

	// Use this for initialization
	void Start () {

        euMesmo = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            euMesmo.AddForce(new Vector2(-1 * moduloForca,0));
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            euMesmo.AddForce(new Vector2(moduloForca, 0));
        }  

        euMesmo.gravityScale = 0;

        if (Input.GetAxisRaw("Vertical") < 0)
        { 
            euMesmo.AddForce(new Vector2(0, -1 * moduloForca));
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            euMesmo.AddForce(new Vector2(0,  moduloForca));
        }



    }
}
