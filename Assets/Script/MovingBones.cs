using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBones : MonoBehaviour
{
    public List<GameObject> boneList;
    public GameObject rotationPoint;

    public GameObject indicator;
    GameObject bone;

    int boneIndex;

    // Start is called before the first frame update
    void Awake()
    {
        boneIndex = 0;
        bone = boneList[boneIndex];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (boneIndex < 26)
            {
                boneIndex += 1;
                bone = boneList[boneIndex];
            }
            else
            {
                boneIndex = 0;
                bone = boneList[boneIndex];
            }

            indicator.transform.position = bone.transform.position;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationPoint.transform.Rotate(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            rotationPoint.transform.Rotate(0, 1, 0);
        }

        float posx = Input.GetAxis("Horizontal");
        float posy = Input.GetAxis("Vertical");

        bone.transform.Rotate(0, 0, posy);
        bone.transform.Rotate(posx, 0, 0);

        Debug.Log(bone);
    }
}