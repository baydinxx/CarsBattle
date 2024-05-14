using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HareketCs : MonoBehaviour
{



    [SerializeField] DynamicJoystick D_joystick;
    float horizontalInput;
    float verticalInput;
    bool GasOn;
    bool ReverseOn;
  
    [SerializeField]  float Speed ;


    bool isBreak;
    float CurrentBreakForce;
    float CurrentTurningAngle;
    Button Gaz;
    Rigidbody RB;

    [SerializeField] float MotorTorqueForce;
    [SerializeField] float breakforce;
    [SerializeField] float MaxturningAngle;
    [SerializeField] WheelCollider FL_Colider;
    [SerializeField] WheelCollider FR_Colider;
    [SerializeField] WheelCollider RR_Colider;
    [SerializeField] WheelCollider RL_Colider;

    [SerializeField] Transform FL_Wheel;
    [SerializeField] Transform FR_Wheel;
    [SerializeField] Transform RL_Wheel;
    [SerializeField] Transform RR_Wheel;

    public void Start()
    {
       RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        InputSystem();
        MoveControl();
        Joystick();
        RotateCar();
        RotateWheel();


    }



    public void RotateWheel()
    {
        RotateTheWhell(FL_Colider, FL_Wheel);
        RotateTheWhell(FR_Colider, FR_Wheel);
        RotateTheWhell(RL_Colider, RL_Wheel);
        RotateTheWhell(RR_Colider, RR_Wheel);
        
    }

    public void RotateTheWhell (WheelCollider WheelsColider,Transform WheelsTransform) 
    {
        Vector3 position;
        Quaternion rotation;
        WheelsColider.GetWorldPose (out position, out rotation);
        WheelsTransform.position = position;
        WheelsTransform.rotation = rotation;
    
    
    }
  
    public void RotateCar()
    {
 


        CurrentTurningAngle = MaxturningAngle * horizontalInput;
        FL_Colider.steerAngle = CurrentTurningAngle;
        FR_Colider.steerAngle = CurrentTurningAngle;
    }

    public void InputSystem()//input
    {
        horizontalInput = D_joystick.Horizontal;
       
    
        
    }

    public void BreakSystem()
    {
        isBreak = true;
    }
    public void moveGas()
    {
        GasOn = true;
        isBreak = false;
        MoveControl();

    }
    public void moveGasNon()
    {
        GasOn = false;
        isBreak = true;
    }
    public void Reversego()
    {
        Debug.Log("gerivites");
        ReverseOn = true;
            Reverse();
        isBreak = false;
    }
    public void ReverseNon()
    { 
        ReverseOn = false;
        isBreak = true;
    }

    public  void Reverse()
        {
        if (ReverseOn)
        {
            FL_Colider.motorTorque = MotorTorqueForce * -1;
            FR_Colider.motorTorque = MotorTorqueForce * -1;
        }
            
        }


public void MoveControl()//hareket kontrol
    {
        if (GasOn)
        {
            FL_Colider.motorTorque = Speed * MotorTorqueForce;
            FR_Colider.motorTorque = Speed * MotorTorqueForce;
        }
        
      

       CurrentBreakForce = isBreak ? breakforce: 0f;

        if (isBreak) 
        {
            FL_Colider.brakeTorque = CurrentBreakForce;
            FR_Colider.brakeTorque = CurrentBreakForce;
            RL_Colider.brakeTorque = CurrentBreakForce;
            RR_Colider.brakeTorque = CurrentBreakForce;

        }
        else
        {
            FL_Colider.brakeTorque = 0f;
            FR_Colider.brakeTorque = 0f;
            RL_Colider.brakeTorque = 0f;
            RR_Colider.brakeTorque = 0f;


        }
    }

    public void Joystick()
    {
        horizontalInput = D_joystick.Horizontal;
        verticalInput = D_joystick.Vertical;
    }



}
