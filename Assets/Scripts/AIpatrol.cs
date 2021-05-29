using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpatrol : MonoBehaviour
{
    public float speed;
    //distance of ray
    public float distance;
    private bool movingRight = true;

    public Transform groundDetection;
    
    void Update() 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        int layer_mask_door = LayerMask.GetMask("door");
        int layer_mask_enemy = LayerMask.GetMask("Enemy");
        
        // door and border
        RaycastHit2D wallInfoRight = Physics2D.Raycast(groundDetection.position, Vector2.right, distance, layer_mask_door);
        RaycastHit2D wallInfoLeft = Physics2D.Raycast(groundDetection.position, Vector2.left, distance, layer_mask_door);
        // enemy
        RaycastHit2D wallInfoRight_enemy = Physics2D.Raycast(groundDetection.position, Vector2.right, distance, layer_mask_enemy);
        RaycastHit2D wallInfoLeft_enemy = Physics2D.Raycast(groundDetection.position, Vector2.left, distance, layer_mask_enemy);


        if ((movingRight == true && wallInfoRight.collider == true)) {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        } else if ((movingRight == false && wallInfoLeft.collider == true)) {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true; 
        }
        

    }
}
