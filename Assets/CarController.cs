using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RaceCarControl
{
    public class CarCntrl : MonoBehaviour
    {
        public bool gazuet, tormozit, dvizenie, stoit;
        public const float acc = 8f;
        float accTime;

        public const float posiSpeed = 80f;
        public const float antiSpeed = -20f;
        public float currSpeed;
        public TMP_Text speedText;
        public GameObject car;
        public bool isRotate;

        public static float currentWheelAngle;

        void Start()
        {
            gazuet = false;
            tormozit = false;
            dvizenie = false;
            stoit = true;
            currSpeed = 0f;
        }
        public void changeRotate()
        {
            isRotate = true;
        }
        void FixedUpdate()
        {
            stoit = !(gazuet || tormozit || dvizenie);
            if (currSpeed < -2 || currSpeed > 2) { dvizenie = true; }
            speedText.text = currSpeed.ToString();
            Vector3 rotateCar = transform.eulerAngles;
            if (isRotate)
            {

                if (dvizenie && currSpeed > 0) { rotateCar.y -= Time.fixedDeltaTime * -wheel_rotate.currentWheelAngle; }
                if (dvizenie && currSpeed > 0) { rotateCar.y += Time.fixedDeltaTime * wheel_rotate.currentWheelAngle; }
                if (dvizenie && currSpeed < 0) { rotateCar.y -= Time.fixedDeltaTime * wheel_rotate.currentWheelAngle; }
                if (dvizenie && currSpeed < 0) { rotateCar.y += Time.fixedDeltaTime * -wheel_rotate.currentWheelAngle; }
                isRotate = false;
            }
            else 
            {
                rotateCar.y = transform.eulerAngles.y;
            }
            

            if (gazuet && accTime <= currSpeed / acc) { accTime += Time.fixedDeltaTime * 10; }
            if (tormozit && accTime >= currSpeed / acc) { accTime -= Time.fixedDeltaTime * 10; }

            currSpeed = acc * accTime;
            if (currSpeed > posiSpeed) { currSpeed = posiSpeed; }
            if (currSpeed < antiSpeed) { currSpeed = antiSpeed; }


            float ugolCar = Mathf.Deg2Rad * rotateCar.y;
            //transform.Translate(Vector3.forward * currSpeed * Time.fixedDeltaTime);
            car.transform.position += new Vector3(currSpeed * Time.fixedDeltaTime * Mathf.Sin(ugolCar), 0, currSpeed * Time.fixedDeltaTime * Mathf.Cos(ugolCar));
            car.transform.rotation = Quaternion.Euler(rotateCar);
        }

        public void gaz()
        {
            if (!tormozit)
                gazuet = true;
        }
        public void tormoz()
        {
            if (!gazuet)
                tormozit = true;
        }

        public void gazStop()
        {
            gazuet = false;
        }
        public void tormozStop()
        {
            tormozit = false;
        }
    }
}