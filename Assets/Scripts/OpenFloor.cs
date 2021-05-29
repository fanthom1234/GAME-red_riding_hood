using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFloor : MonoBehaviour
{
    //public Animator animator;
    public GameObject destroyEff;
    public float duration;

    // Update is called once per frame
    public void gotHit() 
    {
        //animator.SetTrigger("End", true);
        GameObject smoke = Instantiate(destroyEff, transform.position, Quaternion.identity);
        //ok wait...
        Destroy(smoke, duration);
        Destroy(gameObject);
    }
}
