using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    public Transform playerBody;
    public Joystick Joystick;

    private float xRotation = 0f;    
    private PlayerControllerBoll playerControllerBoll;
    private ManagerBoll managerBoll;
    private void Start()
    {
        playerControllerBoll =GameObject.Find("Player").GetComponent<PlayerControllerBoll>();    
        managerBoll = GameObject.Find("Game Manager").GetComponent<ManagerBoll>();
    }
    void Update()
    {
        RotateCameras();
    }
    void RotateCameras()
    {
        if (!playerControllerBoll.gameOver)
        {
            float inputJoy = Joystick.Horizontal;
            transform.Rotate(Vector3.up, inputJoy * rotationSpeed * Time.deltaTime);
        }                   
    }
}
