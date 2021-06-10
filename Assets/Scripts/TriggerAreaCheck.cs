//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class TriggerAreaCheck : MonoBehaviour
//{
//    private EnemyObj enemyParent;
//
//    private void Awake()
//    {
//        if (enemyParent != null)
//            enemyParent = GetComponentInParent<EnemyObj>();
//    }
//
//    private void OnTriggerEnter2D (Collider2D collider)
//    {
//        if (collider.gameObject.CompareTag("Player"))
//        {
//            enemyParent.seePlayer = true;
//        }
//    }
//
//    private void OnTriggerExit2D (Collider2D collider)
//    {
//        if (collider.gameObject.CompareTag("Player"))
//        {
//            enemyParent.seePlayer = false;
//        }
//    }
//}
