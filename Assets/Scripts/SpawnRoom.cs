using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LayerMask whatIsRoom;
    public LevelGeneration levelGen;
    public GameObject[] backGround;

    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if (roomDetection == null && levelGen.stopGeneration == true) {
            int rand = Random.Range(0, levelGen.rooms.Length);
            //if else here, make floor smooth, use overlap circle and room type
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }   
        //gen end destroy center collider and itself 
        if (roomDetection != null && levelGen.stopGeneration == true) {
            //instantiate bg
            int rand = Random.Range(0, backGround.Length);
            //shift z to make it go to background
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 1);
            Instantiate(backGround[rand], transform.position, Quaternion.identity);

            //destroy center collider
            roomDetection.GetComponent<Collider2D>().enabled = false;
            //destroy itself
            Destroy(gameObject);
        }
    }
}
