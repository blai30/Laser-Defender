﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public GameObject projectile;
    public float health;
    public float projectileSpeed;
    public float frequency;
    public int scoreValue;
    public AudioClip fireSound;
    public AudioClip deathSound;
    private ScoreKeeper scoreKeeper;

    void Start() {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update() {
        float probability = frequency * Time.deltaTime;
        if (Random.value < probability) {
            Fire();
        }
    }

    void Fire() {
        Vector3 startPosition = transform.position + new Vector3(0, -0.5f, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile) {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0) {
                Die();
            }
        }
    }

    void Die() {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        scoreKeeper.Score(scoreValue);
        Destroy(gameObject);
    }

}
