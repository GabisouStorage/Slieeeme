using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

public AudioSource	click;
public AudioSource play;

private static bool sfxmanExists;

	// Use this for initialization
	void Start () {
		if(!sfxmanExists) {
			sfxmanExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
