using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    public Vector3 offSet;


    private void FixedUpdate()
    {
        Vector3 desired = target.position + offSet;

        Vector3 smoothed = Vector3.Lerp(transform.position, desired, smoothTime * Time.deltaTime);
        transform.position = smoothed;
    }
}
