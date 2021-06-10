using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform player;
    public float cameraDist = 30.0f;

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDist);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
    }
}
