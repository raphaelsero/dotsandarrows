using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour {

	public KeyCode key;
	bool active = false;
	GameObject note;
	private Renderer rend;
	public float timer = 0.0f;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.5f) {//change the float value here to change how long it takes to switch.
			Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
			rend.material.color = newColor;
			timer = 0;
		}

		if (Input.GetKeyDown (key) && active) {
			Destroy (note);
		}			
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		active = true;
		if (col.gameObject.tag == "Note") {
			Destroy (col.gameObject);
			note = col.gameObject;
		}
	}

	void TriggerExit2D(Collider2D col){
		active = false;
	}
}
