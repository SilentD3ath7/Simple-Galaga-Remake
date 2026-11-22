using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    [Header("Set this in Inspector for specifically the PlayerBullet child class")]
    [Tooltip("This changes the amount of points given to the player")]
    public int points = 1;
    [HideInInspector] public Score scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        // Find a reference to the Score GameObject
        GameObject scoreText = GameObject.Find("Score");
        scoreCounter = scoreText.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    // For when the PlayerBullet collides with the enemy
    private void OnCollisionEnter(Collision coll)
    {
        GameObject collide = coll.gameObject;

        Destroy(this.gameObject);

        if (collide.CompareTag("Enemy"))
        {
            scoreCounter.score += points;
            collide.SetActive(false);
        }
        else if (collide.CompareTag("EnemyBullet"))
        {
            Destroy(collide);
        }
    }

    // How the PlayerBullet moves to the enemy
    public void BulletMove()
    {
        Vector3 pos = transform.position;

        pos.y += bulletSpeed * Time.deltaTime;
        transform.position = pos;

        // If the bullet passes the boundry it destroys itself
        if (transform.position.y > boundY)
        {
            Destroy(this.gameObject);
        }
    }
}