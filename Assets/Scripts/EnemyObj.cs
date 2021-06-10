using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObj : MonoBehaviour
{
    //transform player
    [Header("Raycast")]
    //raycast tile
    public float groundRaycastDistance;
    public Transform tileDetection;

    [Space(5)]
    [Header("Enemy")]
    //accessoriesszz
    public Animator animator;
    public float speed;
    private bool movingRight = true;
    private bool seePlayer;

    [Space(5)]
    [Header("Attack pos")]
    //for checking player
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public LayerMask playerLayer;

    void Update() 
    {
        Collider2D[] hitPlayer = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, playerLayer);
            if (hitPlayer.Length > 0)
            {
                seePlayer = true;
            }
            else
            {
                seePlayer = false;
            }

        //// WALKING!! ////
        if (seePlayer == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (seePlayer == true)
        {
                ////attack yeet
                animator.SetTrigger("Attack");
        }

        animator.SetBool("canWalk", true);

        int collidedLayers = LayerMask.GetMask("door", "RoomTile", "spike", "Border", "Floor", "Enemy");
        RaycastHit2D collidedFront  = Physics2D.Raycast(tileDetection.position, Vector2.right, groundRaycastDistance, collidedLayers);
        RaycastHit2D collidedGround = Physics2D.Raycast(tileDetection.position, Vector2.down, groundRaycastDistance, collidedLayers);

        //NO GROUND, TURN!!
        if (collidedGround.collider == false)
        {
            if (movingRight == true) 
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } 
            else //(movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            } 
        }

        //HAVE GROUND, TURN!!
        else if (collidedGround.collider == true)
        {
            if (collidedFront.collider == true && movingRight == true) 
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } 
            else if (collidedFront.collider == true && movingRight == false) //you need this somehow, u cant just "else" it
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            } 
        }
    }

    public void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, playerLayer);
        foreach (Collider2D player in hitPlayer) 
        {
            player.GetComponent<PlayerHealth>().die();
        }
    }

    public void Die()
    {
        //die
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(tileDetection.position, groundRaycastDistance);
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 0));
    }
}