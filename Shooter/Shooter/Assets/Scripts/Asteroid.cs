using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 directionToMove;
    private Vector3 targetPosition;
    public float moveSpeed;
    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
        directionToMove = GameManager.instance.player.transform.position + transform.position;
        directionToMove.Normalize();
        targetPosition = GameManager.instance.player.transform.position;
    }

    private void Update()
    {
        transform.position -= directionToMove * moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Destroy(this.gameObject);
    }

}
