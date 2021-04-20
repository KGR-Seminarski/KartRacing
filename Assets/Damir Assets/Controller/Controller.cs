using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace KartRacing.Editor
{
    public class Controller : MonoBehaviour
    {
        
   
    private float HorizontalInput;
    private float VerticalInput;
    private float SteerAngle;
    private bool IsBreaking;
    
    
    
    //[SerializeField] private GameObject Kart;
    
    private float BreakForce;
    
    [SerializeField] private float MotorForce;
    [SerializeField] private float BrreakForce;
    [SerializeField] private float MaxSteerAngle;
    
    [SerializeField] private WheelCollider FrontLeftWheelCollider;
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider RearLeftWheelCollider;
    [SerializeField] private WheelCollider RearRightWheelCollider;
    
    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;
    
    
    
    
    
    
    private void Update()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        //Kart.transform.position = new Vector3(0, 0,  HorizontalInput * Time.deltaTime);
        //UpdateWheels();
    }
    
    
    
    
    private void GetInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        IsBreaking = Input.GetKey(KeyCode.Space);
    }
    
    private void HandleMotor()
    {
        FrontLeftWheelCollider.motorTorque = VerticalInput * MotorForce;
        FrontRightWheelCollider.motorTorque = VerticalInput * MotorForce;
        BreakForce = IsBreaking ? BrreakForce : 0f;
        if (!IsBreaking)
        {
            RealaseBrakePedal();
        }
        else
        {
            Brake();
        }
       
    }
    
    private void RealaseBrakePedal()
    {
        FrontRightWheelCollider.brakeTorque = FrontLeftWheelCollider.brakeTorque = RearRightWheelCollider.brakeTorque = RearLeftWheelCollider.brakeTorque = 0f;
    
    }
    
    private void Brake()
    {
        FrontLeftWheelCollider.brakeTorque = BreakForce;
        FrontRightWheelCollider.brakeTorque = BreakForce;
        RearLeftWheelCollider.brakeTorque = BreakForce;
        RearRightWheelCollider.brakeTorque = BreakForce;
    
    }
    private void HandleSteering()
    {
        SteerAngle = MaxSteerAngle * HorizontalInput;
        FrontLeftWheelCollider.steerAngle = SteerAngle;
        FrontRightWheelCollider.steerAngle = SteerAngle;
    }
    private void UpdateWheels()
    {
        UpdateWheel(FrontLeftWheelCollider,FrontLeftWheelTransform);
        UpdateWheel(FrontRightWheelCollider,FrontRightWheelTransform);
        UpdateWheel(RearRightWheelCollider,RearRightWheelTransform);
        UpdateWheel(RearLeftWheelCollider,RearLeftWheelTransform);
    }
    
    private void UpdateWheel(WheelCollider WheelCollider, Transform fWheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        WheelCollider.GetWorldPose(out position,out rotation);
        fWheelTransform.rotation = rotation;
        fWheelTransform.position = position;
    
    }
     }
}

