using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 2;

    private Transform player;
    private UnityEngine.AI.NavMeshAgent nav;


    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav.SetDestination(player.position);   
    }

    //void FixedUpdate () {
      //  transform.LookAt(player);
        //   if (Vector3.Distance(transform.position, player.position) >= MinDist &&
          // Vector3.Distance(transform.position, player.position) <= MaxDist)
        //{
          //  transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //}
    //}
}
