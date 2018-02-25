using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage;

    float GetDamage() {
        return damage;
    }

    void Hit() {
        Destroy(gameObject);
    }

}
