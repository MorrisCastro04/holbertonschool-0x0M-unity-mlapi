using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Movement : NetworkBehaviour
{
    public float currentSpeed = 0f;
    public float maxSpeed = 10f;
    public float currentRotation = 0f;
    public float maxRotation = 100f;

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            currentSpeed = maxSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            currentRotation = maxRotation * Input.GetAxis("Horizontal") * Time.deltaTime;

            transform.Translate(0, 0, currentSpeed);
            transform.Rotate(0, currentRotation, 0);
        }
    }
}
