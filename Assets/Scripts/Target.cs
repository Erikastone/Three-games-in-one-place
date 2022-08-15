using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour
{
    private Rigidbody rbTarget;
    private AudioSource audioS;
    private GameManagerGameTo gameManagerG;
   
    public float minspeed = 14;
    public float maxSpeed = 17;
    public float maxTorqua = 6;
    public float xRange = 1;
    public float ySpawnPos = -4;
    public AudioClip audioClipBoom; 
    public int pointValue;
    public ParticleSystem particleSystemBoom;  
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        rbTarget = GetComponent<Rigidbody>();       
        rbTarget.AddForce(RandomForce(), ForceMode.Impulse);
        rbTarget.AddTorque(RandomTorqua(), RandomTorqua(), RandomTorqua(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManagerG = GameObject.Find("Game Manager").GetComponent<GameManagerGameTo>();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minspeed, maxSpeed);
    }
    float RandomTorqua()
    {
        return Random.Range(-maxTorqua, maxTorqua);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    private void OnMouseDown()
    {       
        if (gameManagerG.isGameActive)
        {
            // audioS.PlayOneShot(audioClipBoom, 1.0f);
            AudioSource.PlayClipAtPoint(audioClipBoom, new Vector3(0, 0, 0));
            Destroy(gameObject);
            Instantiate(particleSystemBoom, transform.position, particleSystemBoom.transform.rotation);           
            gameManagerG.UpdateScore(pointValue);           
        }           
    }   
        private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManagerG.GameOver();
        }      
    }  
}
