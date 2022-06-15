using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    public WheelCollider frontLeft_W, frontRight_W;
    public WheelCollider rearLeft_W, rearRight_W;
    public Transform frontLeft_T, frontRight_T;
    public Transform rearLeft_T, rearRight_T;
    public float maxSteerAngle = 30;
    public float maxForce = 50;

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        frontLeft_W.steerAngle = steeringAngle;
        frontRight_W.steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        rearLeft_W.motorTorque = maxForce * verticalInput;
        rearRight_W.motorTorque = maxForce * verticalInput;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontLeft_W, frontLeft_T);
        UpdateWheelPose(frontRight_W, frontRight_T);
        UpdateWheelPose(rearLeft_W, rearLeft_T);
        UpdateWheelPose(rearRight_W, rearRight_T);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
