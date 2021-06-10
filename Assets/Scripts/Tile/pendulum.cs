using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour
{
    Rigidbody2D rgb2d;
    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;
    bool movingClockwise;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void changeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        changeMoveDir();
        
        if (movingClockwise == true)
        {
            rgb2d.angularVelocity = moveSpeed;
        } 
        if (movingClockwise == false)
        {
            rgb2d.angularVelocity = -1 * moveSpeed;
        }
    }
}
