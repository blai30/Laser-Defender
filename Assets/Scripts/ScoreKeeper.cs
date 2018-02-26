using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;

    void Score(int points) {
        score += points;
    }

    void Reset() {
        score = 0;
    }

}
