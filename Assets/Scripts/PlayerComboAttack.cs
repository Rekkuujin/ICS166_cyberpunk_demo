using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttack : MonoBehaviour {

    float lastAttackTime = 0.0f;
    int AttackCount = 0;
    Animator anim;
    public GameObject attackSphere;
    SphereCollider trigger;
    public ParticleSystem fire;
    AudioSource asrc;
    public AudioClip fireball;

    private void Start()
    {
        anim = GetComponent<Animator>();
        trigger = attackSphere.GetComponent<SphereCollider>();
        asrc = GetComponent<AudioSource>();
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Time.time - lastAttackTime > 0.75f)
            ResetCombo();
	}
    void Attack()
    {
        if (lastAttackTime == 0.0f && AttackCount == 0)
        {
            StartCoroutine("HitBoxTrigger");
            fire.startSize = 2;
            fire.startSpeed = 1;
            fire.Emit(10);
            
            asrc.PlayOneShot(fireball);
            AttackCount++;
        }
        else if ((Time.time - lastAttackTime) <= .75f && AttackCount == 1)
        {
            StartCoroutine("HitBoxTrigger");
            fire.startSize = 3;
            fire.startSpeed = 2;
            fire.Emit(20);
            asrc.PlayOneShot(fireball);
            AttackCount++;
        }
        else if ((Time.time - lastAttackTime) <= 0.75f && AttackCount == 2)
        {
            StartCoroutine("HitBoxTrigger");
            fire.startSize = 4;
            fire.Emit(50);
            asrc.PlayOneShot(fireball);
            AttackCount = 0;
        }
        
        lastAttackTime = Time.time;
    }

    IEnumerator HitBoxTrigger()
    {
        trigger.enabled = true;
        yield return new WaitForSeconds(0.05f);
        trigger.enabled = false;
    }
    void ResetCombo()
    {
        lastAttackTime = 0.0f;
        AttackCount = 0;
    }
}
