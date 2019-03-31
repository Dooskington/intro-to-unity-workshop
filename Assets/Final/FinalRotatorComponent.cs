using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRotatorComponent : MonoBehaviour
{
    public float speed = 45.0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
    }
}
