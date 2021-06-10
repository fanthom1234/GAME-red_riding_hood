using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 2;

    public void Hurt()
    {
        //player animation

        //hurt
    }

    public void die()
    {
        //play animation
        Debug.Log("Pew, u ded btch");
        //restart at first room, timer not reset 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
