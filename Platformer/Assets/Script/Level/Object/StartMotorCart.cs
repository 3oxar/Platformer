using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMotorCart : MonoBehaviour
{
    [SerializeField] private WheelJoint2D[] wheelJoints;
    [SerializeField] private GameObject cart;

    [SerializeField] private float speed;

    private JointMotor2D jointMotor;

    // Start is called before the first frame update
    void Start()
    {
        jointMotor.maxMotorTorque = Mathf.Abs(speed);
        jointMotor.motorSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            foreach (var joint in wheelJoints)
            {
                joint.useMotor = true;
                joint.motor = jointMotor;
            }
        }
    }

  


}
