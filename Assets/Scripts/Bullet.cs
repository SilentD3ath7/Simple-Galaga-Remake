using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Set these in Inspector for parent Bullet class")]
    [Range(0f, 15f)]
    [Tooltip("This is for the speed of the bullet")]
    // These are universal variables for each type of bullet
    public float bulletSpeed = 7f;
    public float boundY = 7.5f;
}
