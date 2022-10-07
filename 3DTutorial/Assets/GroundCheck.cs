using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround;
    public float distanceToCheck = 0.5f;
    
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}
