using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveLeft : MonoBehaviour
{
    public float speedMove = 15;

    private float maxLeft = -10;
    private PlayerController playerControllerScript;
    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime, Space.World);
        }
           
        if (transform.position.x < maxLeft && !gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
