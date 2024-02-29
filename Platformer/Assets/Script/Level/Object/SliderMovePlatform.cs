using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovePlatform : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private JointMotor2D jointMotor;

    private float motorSpeed;

    void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        jointMotor = sliderJoint.motor;
        motorSpeed = jointMotor.motorSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joint"))
        {
            StartCoroutine(ChangMotorSpeed());
        }
    }

    private IEnumerator ChangMotorSpeed()
    {
        yield return new WaitForSeconds(0.5f);

        motorSpeed *= -1;
        jointMotor.motorSpeed = motorSpeed;
        sliderJoint.motor = jointMotor;
    }
}
