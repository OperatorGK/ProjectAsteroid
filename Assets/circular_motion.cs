using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular_motion : MonoBehaviour {
    public Vector3 center;
    public Vector3 axis;
    public float frequency;
    public bool reverseForwardAndUpward;

    private Transform _transform;


	// Use this for initialization
	void Start () {
        _transform = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        _transform.RotateAround(center, axis, frequency * 360 * Time.deltaTime);

        // Forward vector aligned to radius vector, upward vector aligned to velocity vector
        if (reverseForwardAndUpward)
            _transform.LookAt(2*_transform.position-center, _transform.position+Vector3.Cross(axis, _transform.position - center));
        // Forward vector aligned to velocity vector, upward vector aligned to radius vector
        else _transform.LookAt(_transform.position + Vector3.Cross(axis, _transform.position - center), 2 * _transform.position - center);

    }
}
