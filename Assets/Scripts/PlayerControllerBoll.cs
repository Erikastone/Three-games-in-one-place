using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class PlayerControllerBoll : MonoBehaviour
{
    public float speed;
    public int normalSpeed = 6;
    public GameObject powerupIndicators;
    public bool hasPowerUp;
    public bool gameOver = false;   

    private GameObject focalPoint;
    private Rigidbody rbPlayer;
    private float powerupStrenght = 15.0f;
    private ManagerBoll managerBoll;
    void Start()
    {
        speed = 0f;
        rbPlayer = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        managerBoll = GameObject.Find("Game Manager").GetComponent<ManagerBoll>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (!gameOver)
        {
           rbPlayer.AddForce(focalPoint.transform.forward * speed );
            rbPlayer.AddForce(focalPoint.transform.forward * speed );
            powerupIndicators.transform.position = transform.position + new Vector3(0, -0.5f, 0);           
        }                     
    }
    public void OnUpButtonDown()
    {
        if (speed>=0f)
        {
            speed = -normalSpeed;
        }
    }
    public void OnDownButtonDown()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }
    public void OnButtonUp()
    {
        speed = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCounDownRounTime());
            powerupIndicators.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerupCounDownRounTime()
    {
        yield return new WaitForSeconds(7);
        powerupIndicators.gameObject.SetActive(false);
        hasPowerUp = false;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collider with" + collision.gameObject.name + "with powerup set to" + hasPowerUp);
            enemyRb.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("Death"))
        {
            gameOver = true;           
            managerBoll.GameOver();           
            Debug.Log("Game Over!");
        }
    }
}
