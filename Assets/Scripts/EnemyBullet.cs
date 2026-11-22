using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    // Function for when the EnemyBullet collides with the player
    private void OnCollisionEnter(Collision coll)
    {
        GameObject collide = coll.gameObject;

        Destroy(collide);
        Destroy(this.gameObject);
    }

    // How the EnemyBullet moves towards the player
    public void BulletMove()
    {
        Vector3 pos = transform.position;

        pos.y -= bulletSpeed * Time.deltaTime;
        transform.position = pos;

        // If the bullet passes the boundry it destroys itself
        if (transform.position.y < -boundY)
        {
            Destroy(this.gameObject);
        }
    }
}
