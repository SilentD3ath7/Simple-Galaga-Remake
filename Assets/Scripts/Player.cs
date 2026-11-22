using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Set these in Inspector")]
    public GameObject playerBulletPrefab; // This is for instantiating the PlayerBullet
    public GameManager gameManager;
    public static float boundX = 8f; // The universal boundry for x pos
    [Range(0f, 10f)] [Tooltip("This is for the speed of the Player")] public float speed = 5f;
    [HideInInspector] public KeyCode moveLeft = KeyCode.A, moveRight = KeyCode.D;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerShoot();
        PlayerMove();
    }

    // When the player gets destroyed by an EnemyBullet it ends the game
    private void OnDestroy()
    {
        gameManager.GameOver();
    }

    // Everytime the player clicks the left mouse button, a bullet is spawned at the player and moves towards the enemy
    private void PlayerShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject pBullet = Instantiate<GameObject>(playerBulletPrefab, this.transform.position, Quaternion.Euler(-90, 0, 0));

            pBullet.transform.position = transform.position;
        }
    }

    private void PlayerMove()
    {
        var velocity = rb.velocity;
        var pos = transform.position;

        // Player Movement
        if (Input.GetKey(moveLeft))
        {
            velocity.x = -speed;
        }
        else if (Input.GetKey(moveRight))
        {
            velocity.x = speed;
        }
        else
        {
            velocity.x = 0;
        }
        rb.velocity = velocity;

        // Boundry for Player
        if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }
        else if (pos.x > boundX)
        {
            pos.x = boundX;
        }
        transform.position = pos;
    }
}