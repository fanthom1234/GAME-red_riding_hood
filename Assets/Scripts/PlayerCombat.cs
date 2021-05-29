using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint; //can use this to spawn spear randomly
    
    // To detect what is enemy
    public LayerMask enemyLayers;
    public LayerMask floorLayers;
    public LayerMask doorLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2.0f;
    float nextAttackTime = 0f;
    
    public float health = 1;

    //// GODDDDD
    public LayerMask godStand;
    public RuntimeAnimatorController anim2;
    public GameObject effStand;

    void Update()
    {
        //atk rate
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play an attack animation
        int randAtk = Random.Range(1, 4);
        animator.SetTrigger("Attack" + randAtk);

        //Detect enemies in range of attack
        //store ALL enemies we hit in array
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            //get component from obj :D scripts blablabla
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        
        //GODDDDD!!!!!
        Collider2D[] hitStand = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, godStand);

        if (hitStand.Length > 0)
        {
        GameObject smoke = Instantiate(effStand, transform.position, Quaternion.identity);
        smoke.transform.localScale = new Vector3(2.5f, 2.5f, 0f);
        Destroy(smoke, 0.5f);
        this.GetComponent<Animator>().runtimeAnimatorController = anim2 as RuntimeAnimatorController;
        }

        Collider2D[] hitFloors = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, floorLayers);

        foreach (Collider2D floor in hitFloors)
        {
            floor.GetComponent<OpenFloor>().gotHit();
        }

        Collider2D[] hitDoor = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, doorLayers);

        foreach (Collider2D door in hitDoor)
        {
            door.GetComponent<OpenDoor>().gotHit();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void gotHit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
