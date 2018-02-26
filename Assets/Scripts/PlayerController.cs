﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    public float padding;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate;
    public float health;
    public AudioClip fireSound;
    private float xmin;
    private float xmax;

	// Use this for initialization
	void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("Fire");
        }

		if (Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;;
		}

        // Restrict player to game space
        float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
        this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);

	}

    void Fire() {
        Vector3 startPosition = this.transform.position + new Vector3(0, 0.5f, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, this.transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile) {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }

}
