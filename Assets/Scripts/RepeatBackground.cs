using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float backgroundHalf = 2f;
    private PlayerController playerControllerScript;

    public float speedMove =10;  
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / backgroundHalf;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }    
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime, Space.World);
        }
        if (transform.position.x < startPos.x - repeatWidth)
        {          
            transform.position = startPos;
        }
    }
}
