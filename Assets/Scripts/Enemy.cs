using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    int health = 75;

    public void Damage(int i)
    {
        health -= i;
        if (health <= 0)
            Destroy(this.gameObject);
    }

}
