using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular_motion : MonoBehaviour {
    public Vector3 axis = Vector3.left;
    public float frequency = 0.5f;
    public bool reverseForwardAndUpward = false;

    protected Transform _transform;
    protected Vector3 center;

	// Use this for initialization
	protected void Start () {
        _transform = this.transform;
        center = GameObject.FindWithTag("Center").transform.position;
    }
	
	// Update is called once per frame
	protected void Update () {
        _transform.RotateAround(center, axis, frequency * 360 * Time.deltaTime);

        // Forward vector aligned to radius vector, upward vector aligned to velocity vector
        if (reverseForwardAndUpward)
            _transform.LookAt(2*_transform.position-center, _transform.position+Vector3.Cross(axis, _transform.position - center));
        // Forward vector aligned to velocity vector, upward vector aligned to radius vector
        else _transform.LookAt(_transform.position + Vector3.Cross(axis, _transform.position - center), 2 * _transform.position - center);

    }
}
