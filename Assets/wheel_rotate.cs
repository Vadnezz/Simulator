using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel_rotate : MonoBehaviour
{
    public static float currentWheelAngle;
    Vector3 rotateWheel ;

    void FixedUpdate()
    {
        rotateWheel = transform.eulerAngles;
        rotateWheel.y = -SteeringWheel.currentAngle*50/180;
        if (rotateWheel.y>50)
        {
            rotateWheel.y = 50;
        }
        if (rotateWheel.y < -50)
        {
            rotateWheel.y = -50;
        }
        //rotateWheel.y > 50 ? rotateWheel.y = 50 : rotateWheel.y = SteeringWheel.currentAngle * 50 / 180;

        transform.rotation = Quaternion.Euler(rotateWheel);
        currentWheelAngle = rotateWheel.y;
    }
    
}
