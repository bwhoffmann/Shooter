using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition;
    public float moveSpeed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
    }
    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        targetPosition = GameManager.instance.player.transform.position;
        Vector3 directionToLook = targetPosition - transform.position;
        transform.right = directionToLook;
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Destroy(this.gameObject);
    }
}
