using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo {
    public WheelCollider m_leftWheel;
    public WheelCollider m_rightWheel;
    public bool m_motor;
    public bool m_steering;
}

public class CarController : MonoBehaviour
{
    public List<AxleInfo> m_axleInfos;
    public float m_maxTorqueSpeed = 150.0f;
    public float m_maxSteeringAngle = 45f;


    public void ApplyLocalPositionVisuals(WheelCollider collider) {
        if(collider.transform.childCount == 0) {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float motor = m_maxTorqueSpeed * Input.GetAxis("Vertical");
        float steering = m_maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in m_axleInfos) {
            if (axleInfo.m_steering) {
                axleInfo.m_leftWheel.steerAngle = steering;
                axleInfo.m_rightWheel.steerAngle = steering;
            }

            if (axleInfo.m_motor) {
                axleInfo.m_leftWheel.motorTorque = motor;
                axleInfo.m_rightWheel.motorTorque = motor;
            }

            ApplyLocalPositionVisuals(axleInfo.m_leftWheel);
            ApplyLocalPositionVisuals(axleInfo.m_rightWheel);
        }
    }
}
