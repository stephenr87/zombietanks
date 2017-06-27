using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    
    public Transform Target;
    public float Smoothing = 3f;

    private GameObject _player;
    private Vector3 _offset;


    void Start()
    {
        _offset = transform.position - Target.position;

        //_player = GameObject.FindGameObjectWithTag("Player");
        //Target = _player.transform;

    }

    void FixedUpdate()
    {
        
        Vector3 targetCamPos = Target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, Smoothing * Time.deltaTime);
    }

}
