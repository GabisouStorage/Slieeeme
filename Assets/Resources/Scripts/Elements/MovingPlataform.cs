using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlataform : MonoBehaviour {

	private Rigidbody2D rb;

	[SerializeField]
	private Vector2 direction;

	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = direction * speed;
	}

	
}
