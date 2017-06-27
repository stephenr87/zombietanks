using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public bool _debug = true;
    public GameObject smokePrefab;
    public GameObject muzzleFlash;
    private Animator anim;

    public float playerDamage = 2f;


    private Vector3 _position;
    private float _direction_y;
    private int shootableLayer;

   
    private RaycastHit hit;
    
	// Use this for initialization
	void Start () {
        shootableLayer = LayerMask.GetMask("Shootable");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Shooting", true);
            Shooting();
        }
        else
        {
            anim.SetBool("Shooting", false);
        }
    }

    void Shooting()
    {
        if(_debug == true) 
        {
            Debug.DrawRay(_position, transform.forward * 1000f, Color.green);
        }

        Projectile();
        
        _position = gameObject.transform.position;   
        if(Physics.Raycast(_position, transform.forward * 1000f, out hit, 20f, shootableLayer))
        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("ENEMY IS HIT");
                hit.transform.GetComponent<Health>().TakeDamage(playerDamage);
            }

        }

    }

    void Projectile()
    {
        GameObject gun = GameObject.FindGameObjectWithTag("Gun");
        //Instantiate<GameObject>(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
        var pew = Instantiate(smokePrefab, gun.transform);
        Destroy(pew, 3f);
        var muzzle = Instantiate(muzzleFlash, gun.transform);
        Destroy(muzzle, 0.13f);


    }


}