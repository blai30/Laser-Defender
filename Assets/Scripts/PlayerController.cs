﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int moveSpeed;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			this.transform.position.x -= moveSpeed;
		}
		
	}

}
