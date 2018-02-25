using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width;
    public float height;
    public float moveSpeed;
    private bool movingRight = true;

	// Use this for initialization
	void Start() {
        foreach(Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}
	
	// Update is called once per frame
	void Update() {
		if (movingRight) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        } else {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

}
