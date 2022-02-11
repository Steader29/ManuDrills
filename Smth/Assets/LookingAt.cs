using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAt : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        Vector3 vect = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(vect);
    }
}
