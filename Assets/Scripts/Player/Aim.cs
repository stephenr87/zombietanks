using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public bool active_laser = false;
    private LineRenderer aimPrefab;

	void Start () {
        aimPrefab = GetComponent<LineRenderer>();
    	}
	
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            if (active_laser)
            {
                active_laser = false;
            } else
            {
                active_laser = true;
            }
        }

        if(active_laser) {
            aimPrefab.enabled = true;
            aimPrefab.SetPosition(0, transform.position);
            aimPrefab.SetPosition(1, transform.forward * 1000f);
        } else
        {
            aimPrefab.enabled = false;
        }
 
    }
}
