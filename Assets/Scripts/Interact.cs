using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    ////Merchant 
    public GameObject merchant;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            //wait then close collider
            StartCoroutine(MyCoroutine());
        }

    }
    IEnumerator MyCoroutine()
    {
        //half sec
        yield return new WaitForSeconds(0.5f);    
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    //private void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag == "merchant")
    //    {
//
    //    }
    //}
}
