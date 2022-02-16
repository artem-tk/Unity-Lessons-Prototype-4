using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody EnemyRB;
    private GameObject Player;
    public float EnemySpeed = 3.0f;

    void Start()
    {
        EnemyRB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 LookDirection = (Player.transform.position - transform.position).normalized;

        EnemyRB.AddForce(LookDirection * EnemySpeed);
    }
}
