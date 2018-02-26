using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKeeper : MonoBehaviour {

	public int health;
    private Text scoreText;

    void Start() {
        scoreText = GetComponent<Text>();
    }

    public void Score(int points) {
        score += points;
        scoreText.text = score.ToString();
    }

    public void Reset() {
        score = 0;
        scoreText.text = score.ToString();
    }

}
