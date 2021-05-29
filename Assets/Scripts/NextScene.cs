using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Animator animator; 
    public float duration;

    void OnCollisionEnter2D(Collision2D coll) 
    {
        //change tag too, tag is layer on easy mode 555
		if (coll.gameObject.tag == "Player") 
        {
            animator.SetBool("End", true);
            
            //for waiting
            StartCoroutine(MyCoroutine());
		}
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(duration);    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
