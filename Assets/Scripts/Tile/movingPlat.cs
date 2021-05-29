using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    bool moveUp = true;
    public Transform center;
    public float moveSpeed = 3f;
    public float topPosFromCen = 4f;
    public float bottPosFromCen = 4f;

    private void Update()
    {
        if (transform.position.y > (center.transform.position.y + topPosFromCen))
            moveUp = false;
        if (transform.position.y < (center.transform.position.y - bottPosFromCen))
            moveUp = true;

        if (moveUp == true)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        else 
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);

    }
}