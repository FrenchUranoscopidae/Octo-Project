using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    private float defaultZ;
    private float counter;
    private float counter2;
    public float initialOffsetX;
    public float initialOffsetZ;
    public float initialOffsetY;
    public float rotationAmountX;
    public float rotationAmountZ;
    public float rotationAmountY;
    public GameObject rootBone;
    public int switchDirection;
    public int switchDirection2;
    private float xAngle;
    private float yAngle;
    private float zAngle;
    private Vector3 initialRotation = new Vector3();

    void Start()
    {
        //Change object's initial rotation to have an equal animation on both sides.
        rootBone.transform.Rotate(initialOffsetX, initialOffsetY, initialOffsetZ);
        initialRotation.Set(rootBone.transform.eulerAngles.x, rootBone.transform.eulerAngles.y, rootBone.transform.eulerAngles.z);
        counter = 0;
        defaultZ = 0;
        yAngle = 0;
        zAngle = 0;
        xAngle = 0;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            counter ++;
            
            if (counter >= switchDirection)
            {
                rotationAmountZ *= -1;
                rotationAmountY *= -1;
                counter = 0;
            }

            yAngle += rotationAmountY;
            zAngle += rotationAmountZ;
            rootBone.transform.eulerAngles = initialRotation+new Vector3(0, transform.eulerAngles.y+yAngle+180.0f, zAngle);
        }
        else
        {
            rootBone.transform.localEulerAngles = new Vector3(0, 0, 0);
            counter2 ++;

            if (counter2 >= switchDirection2)
            {
                rotationAmountX *= -1;
                counter2 = 0;
            }

            xAngle += rotationAmountX;
            rootBone.transform.eulerAngles = new Vector3(initialOffsetX + xAngle, 0, 0);
        }
    }
}
