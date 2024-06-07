using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];

    public float torque = 200;
    public float steeringMax = 4; // fuerza de giro del coche
    public float decelerationRate = 50f; // tasa de desaceleración
    private float currentTorque = 0;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        animateWheels();

        // Aceleración y desaceleración
        if (Input.GetKey(KeyCode.W))
        {
            currentTorque = torque;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentTorque = -torque;
        }
        else
        {
            // Desaceleración gradual
            if (currentTorque > 0)
            {
                currentTorque -= decelerationRate * Time.deltaTime;
                if (currentTorque < 0) currentTorque = 0;
            }
            else if (currentTorque < 0)
            {
                currentTorque += decelerationRate * Time.deltaTime;
                if (currentTorque > 0) currentTorque = 0;
            }
        }

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = currentTorque;
        }

        // Dirección
        if (Input.GetAxis("Horizontal") != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMax; // solo afectará a las ruedas frontales
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = 0; // si dejamos de presionar perderá fuerza
            }
        }
    }

    // Animación de las ruedas
    public void animateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }
}
