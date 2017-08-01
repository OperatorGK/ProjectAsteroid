using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circular_motion : MonoBehaviour {
    public Vector3 center;
    public Vector3 axis_of_rotation;
    public float frequency;

    private Transform _transform;
    private float radius;
    private Vector3 omega;

	// Use this for initialization
	void Start () {
        _transform = this.transform;

        radius = (_transform.position - center).magnitude;
        omega = axis_of_rotation.normalized * (2f * Mathf.PI * frequency); // omega has magnitute w = 2*pi*f
	}
	
	// Update is called once per frame
	void Update () {
        // v = omega x r
        var velocity = Vector3.Cross(omega, _transform.position - center);
        _transform.position += velocity * Time.deltaTime;
        // Correct rounding errors
        _transform.position = (_transform.position - center).normalized * radius + center;

        _transform.LookAt(center);
	}
}
