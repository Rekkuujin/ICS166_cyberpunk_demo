using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackProcess : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<Enemy>().Damage(25);
    }
}
