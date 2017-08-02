using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlled_circular_motion : Circular_motion
{
    public float input_sensivity = 5f;
    public float camera_offset = 20f;

    protected Transform mainCamera;

    new void Start()
    {
        base.Start();
        mainCamera = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    new void Update()
    {
        axis = Quaternion.AngleAxis(input_sensivity * Input.GetAxis("Horizontal"), _transform.position - center) * axis;
        base.Update();
        mainCamera.position = _transform.position.normalized * (_transform.position.magnitude + camera_offset) - center;
        // Forward vector is directed at object position, upward vector aligns with velocity vector
        mainCamera.LookAt(_transform.position, Vector3.Cross(axis, _transform.position - center));
    }
}
