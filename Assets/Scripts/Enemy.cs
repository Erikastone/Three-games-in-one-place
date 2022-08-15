using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedEnemy;

    private Rigidbody rbEnemy;
    private GameObject player;
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        MoveEnemy();
    }
    void MoveEnemy()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rbEnemy.AddForce(lookDirection * speedEnemy);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
