using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {


    public float health = 5f;
    public GameObject TakingDamageParticles;
    public GameObject ExplosionParticles;
    public GameObject BloodParticles;

    private GameObject ParticleParent;
    private bool isDead = false;

    void Start () {
        ParticleParent = GameObject.Find("ParticleGraveyard");

    }

    void Update () {
        if (health <= 0)
        {
            Die();
        }

    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        health -= damage;
        Instantiate(TakingDamageParticles, gameObject.transform);
    }

    void Die()
    {
        isDead = true;

        //capsuleCollider.isTrigger = true;

        //anim.SetTrigger ("Dead");

        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        Debug.Log("Should kill enemy!" + gameObject);
        Instantiate(TakingDamageParticles, gameObject.transform).transform.parent = ParticleParent.transform.parent;
        Instantiate(ExplosionParticles, gameObject.transform).transform.parent = ParticleParent.transform.parent;
        Instantiate(BloodParticles, gameObject.transform).transform.parent = ParticleParent.transform.parent;
        //var body = gameObject.GetComponentInChildren(typeof(MeshRenderer), true) as MeshRenderer;
        //body.enabled = false;

        Destroy(gameObject);
        // Destroy(gameObject, 2f);

    }

}
