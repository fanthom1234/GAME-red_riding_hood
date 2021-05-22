using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    //// ARRAYzz_420_69Xxx
    public Transform[] startingPositions;
    public GameObject[] rooms; //index 0 -> LR, index 1 -> LRB, index 2 -> LRT, index 3 -> LRTB
    //// MOVING
    private int direction; //next move, maybe try enum for ++readability
    public float moveAmount;
    //// ROOM SPAWN DELAY
    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;
    //// KEEP BOX IN THE BOX
    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration; 
    //// Circle to keep track of thing
    public LayerMask room;
    //// Check double down
    private int downCounter = 0;

    private void Start()
    {
        int rand = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[rand].position; //cuz array already is transform lmao
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        //not really sure what this is but, yeah...
        if (timeBtwRoom <= 0 && stopGeneration == false) {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        } else {
            timeBtwRoom -= Time.deltaTime;
        } ////will this keep updating eventhough generation is stop???? 
    }

    private void Move()
    {
        //why it random like this? this algo can be improve
        if (direction == 1 || direction == 2) { //move right then place sprite
            //not more than right border 
            if (transform.position.x < maxX) {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos; 

                //draw whatever lflmaoasdlfd
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                //inorder for sprite to NOT OVERWRITE
                //rand 1 to 5
                //direction for next sprite
                //we prevent dir == 3 or 4 which is left
                //now it will move either right or down
                direction = Random.Range(1, 6);
                if (direction == 3) {
                    direction = 2;
                } else if (direction == 4) {
                    direction = 5;
                }
            } else {
                direction = 5;
            }
            
        } else if (direction == 3 || direction == 4) { //move left then place sprite
            if (transform.position.x > minX) {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;
                
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                //not go right, no 1 and 2 
                direction = Random.Range(3, 6);
            } else {
                direction = 5;
            }
        } else if (direction == 5) { //move down then place sprite
            downCounter++;

            if (transform.position.y > minY) {
                //magic circle to keep track of previous sprite type
                //this line is to make sure that it doesnt collid with other collider except thing in room layer?
                //look it up idk...
                //in room prefab insert box collider and insert layer room
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                //if it doesn't have bottom opening, BOMB that shjit up fam
                //THIS GET COMPONENT IS EXPENSIVE RIGHT? maybe fix later
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3) {
                    
                    ////make it DOUBLE, TRIPLE down, rooms[3] <-- LRTB
                    if (downCounter >= 2) {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    } else { ////NORMAL down eiei
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        //make it room with bottom
                        //**cant named it rand cuz of 'enclose scope..' idk man
                        int randBott = Random.Range(1, 4);
                        if (randBott == 2) { //2 <-- no bottom room
                            randBott = 1; //LRB
                        }
                        Instantiate(rooms[randBott], transform.position, Quaternion.identity); //ใช้ได้เพราะยังไม่ได้กำหนดnew position
                    }
                    
                    
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                //draw room with top, which is 2 and 3
                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);


                //theres no direction up, so rand all
                direction = Random.Range(1, 6);
            } else {
                //STOP LEVEL GEN
                stopGeneration = true;
            }
        }
    }
}
