using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    //Put this in room prefabs to keep track of its type
    public int type;

    public void RoomDestruction() {
        Destroy(gameObject);
    }
}
