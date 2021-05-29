using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    
    //// PLAYER
    public Transform playerAttackPoint;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        ////knockback
        ////if (this.transform.position.x < playerAttackPoint.transform.position.x) //player at right
        ////{
        ////    this.transform.position = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);     
        ////} 
        ////if (this.transform.position.x > playerAttackPoint.transform.position.x) //player at left
        ////{
        ////    this.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);     
        ////}

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy DIE");
        //Die animation
        animator.SetBool("IsDead", true);

        //Disable enemy
        ////GetComponent<Collider2D>().enabled = false;
        ////this.enabled = false;
        Destroy(gameObject);
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag == "Player")
    //    {
    //        coll.gameObject.GetComponent<PlayerCombat>().gotHit();
    //    }
    //}
}
