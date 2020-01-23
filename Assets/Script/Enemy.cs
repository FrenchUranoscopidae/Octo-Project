using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public GameObject playerObject;
    RaycastHit hit;
    Ray ray;

    bool canSee;
    float distance;
    float timer;
    float direction;
    Vector3 originPos;
    
    void Start()
    {
        ray = new Ray();
        canSee = false;
        originPos = transform.position;
        direction = 1;
        timer = 5;
    }

    void Update()
    {
        timer -= 1*Time.deltaTime;
        distance = Vector3.Distance(transform.position, playerObject.transform.position);

        if(!canSee)transform.Translate(0, 0, 0.05f * direction);

        if(timer <= 0)
        {
            direction *= -1;
            timer = 5;
        }

        if (distance <= 5 && !player.camoActive)
        {
            ray.origin = transform.position;
            ray.direction = playerObject.transform.position - transform.position;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    canSee = true;
                }
            }
        }

        if (canSee)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, 0.02f);
            ray.origin = transform.position;
            ray.direction = playerObject.transform.position - transform.position;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ink")
                {
                    canSee = false;
                }
            }
        }
        else transform.position = Vector3.MoveTowards(transform.position, originPos, 0.02f);
    }
}
