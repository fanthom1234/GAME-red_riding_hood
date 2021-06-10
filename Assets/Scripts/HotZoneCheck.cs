//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class HotZoneCheck : MonoBehaviour
//{
//    private Enemy_behaviour enemyParent;
//    private bool inRange;
//    private Animator anim;
//
//    private void Awake()
//    {
//        if (enemyParent != null) 
//        {
//        enemyParent = GetComponentInParent<Enemy_behaviour>();
//        }
//        anim = GetComponentInParent<Animator>();
//    }
//
//    private void Update()
//    {
//        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
//        {
//            enemyParent.Flip();
//        }
//    }
//
//    private void OnTriggerEnter2D(Collider2D collider)
//    {
//        if (collider.gameObject.CompareTag("Player"))
//        {
//            inRange = true;
//        }
//    }
//
//    private void OnTriggerExit2D (Collider2D colldier)
//    {
//        if (colldier.gameObject.CompareTag("Player"))
//        {
//            inRange = false;
//            gameObject.SetActive(false);
//            enemyParent.triggerArea.SetActive(true);
//            enemyParent.inRange = false;  //ooo we can use other script as data type and acces itssa var and method
//        }
//    }
//}
