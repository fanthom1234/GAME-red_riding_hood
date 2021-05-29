using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    //public GameObject openDoor;
    public Sprite newSprite;

    // Update is called once per frame
    public void gotHit() 
    {
       //Instantiate(openDoor, transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().sprite = newSprite;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
