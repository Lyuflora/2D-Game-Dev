using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookat;
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = lookat.position.x - transform.position.x;
    }
}
