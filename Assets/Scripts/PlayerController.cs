using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    public float padding;
    float xmin;
    float xmax;
    float ymin;
    float ymax;

	// Use this for initialization
	void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 upmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        Vector3 downmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        ymin = upmost.y - padding;
        ymax = downmost.y + padding;
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
