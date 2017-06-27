using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] Enemies;
    public int MaxNumberOfEnemies = 3;

    private int currentNumberOfEnemies;
    
	void Start () {
		
	}
	
	void Update () {

        currentNumberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

		if(currentNumberOfEnemies < MaxNumberOfEnemies)
        {
            Instantiate(Enemies[0], gameObject.transform);
        }
	}
}
