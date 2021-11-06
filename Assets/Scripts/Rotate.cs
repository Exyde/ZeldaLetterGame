using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 _rotation;
    void Update()
    {
        transform.Rotate (_rotation);
    }
}
