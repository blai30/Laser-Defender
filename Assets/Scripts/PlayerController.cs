using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int moveSpeed;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			this.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			this.transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
	    }
        
	}

}
