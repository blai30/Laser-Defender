using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width;
    public float height;
    public float moveSpeed;
    private bool movingRight = true;
    private float xmin;
    private float xmax;

    bool AllMembersDead() {
        foreach(Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0) {
                return false;
            }
        }
        return true;
    }

    Transform NextFreePosition() {
        foreach(Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount == 0) {
                return childPositionGameObject;;
            }
        }
        return null;
    }

	// Use this for initialization
	void Start() {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftEdge.x;
        xmax = rightEdge.x;

        SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update() {
		if (movingRight) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        } else {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);
        if(leftEdgeOfFormation < xmin) {
            movingRight = true;
        } else if (rightEdgeOfFormation > xmax) {
            movingRight = false;
        }

        if (AllMembersDead()) {
            SpawnEnemies();
        }
	}

    void SpawnEnemies() {
        foreach(Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull() {
        Transform freePosition = NextFreePosition();
        GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = freePosition;
    }

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

}
