using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShip : MonoBehaviour
{
    public GameObject ebulletPrefab;
    public float ebulletSpeed = 4f;
    private Vector3 targetPosition;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemy2List.Add(this.gameObject);
    }
    private void OnDestroy()
    {
        GameManager.instance.enemy2List.Remove(this.gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        targetPosition = GameManager.instance.player.transform.position;
        Vector3 directionToLook = targetPosition - transform.position;
        transform.right = directionToLook;

        if (GameManager.instance.player != null)
        {
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Destroy(this.gameObject);
    }



    public void Shoot()
    {
        GameObject ebullet = Instantiate(ebulletPrefab, transform.position, transform.rotation);
        ebullet.GetComponent<EBullet>().ebulletSpeed = ebulletSpeed;
        Destroy(ebullet, 2);
    }
}

