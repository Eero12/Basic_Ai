using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public bool pickedUp = false;
    public bool canPickUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 6;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        // Bit shift the index of the layer (8) to get a bit mask


        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.


        // Does the ray intersect any objects excluding the player layer
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Hit " + hit.transform.gameObject.tag);
                if (hit.collider.gameObject.tag == "pickUp" && !pickedUp && canPickUp)
                {
                    hit.collider.gameObject.transform.parent = gameObject.transform;
                    pickedUp = true;
                    canPickUp = false;
                    Invoke("canPickUP", 0.5f);
                }

                else if (pickedUp && canPickUp)
                {
                    transform.DetachChildren();
                    pickedUp = false;
                    canPickUp = false;
                    Invoke("canPickUP", 0.5f);
                }

            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }

    void canPickUP()
    {
        canPickUp = true;
    }
}
