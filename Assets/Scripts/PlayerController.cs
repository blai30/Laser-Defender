using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    float xmin = -5;
    float xmax = 5;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;;
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;;
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			this.transform.position += Vector3.up * moveSpeed * Time.deltaTime;;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			this.transform.position += Vector3.down * moveSpeed * Time.deltaTime;;
	    }

        // Restrict player to game space
        float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
        this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);

	}

}
