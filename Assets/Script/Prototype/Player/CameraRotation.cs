using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public int range = 25;
    public int rotationSpeed = 15;
    public Transform controller;
    public Transform securityCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);

        foreach(Collider hit in hits)
        {
            ObjectController obj = hit.GetComponent<ObjectController>();
            PlayerController player = hit.GetComponent<PlayerController>();

            if(hit.CompareTag("Player") && player.isControlled || hit.CompareTag("ControllableHeavy") && obj.isControlled || hit.CompareTag("ControllableLightweight") && obj.isControlled)
            {
                Vector3 dir = controller.position - securityCamera.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(securityCamera.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
                securityCamera.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }
    }

    private void LateUpdate()
    {
        if (controller == null)
        {
            controller = GameObject.Find("Player(Clone)").transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
