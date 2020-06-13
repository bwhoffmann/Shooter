using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("Collided with something.");
    }

    private void OnCollisionExit2D(Collision2D otherObject)
    {
        Debug.Log("Stopped Colliding.");
    }

    private void OnCollisionStay2D(Collision2D otherObject)
    {

    }

}
