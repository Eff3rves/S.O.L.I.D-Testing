using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float objheight;

    //cast a ray to hit the ground and set the player's feet to where the ground is
    public bool GroundCheckMethod()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, -Vector3.up, out hit, objheight*1.01f))
        {
            //Debug.Log("can jump");
            return true;
        }
        //Debug.Log("cant jump");
        return false;
    }
}
