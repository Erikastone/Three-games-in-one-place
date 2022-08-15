using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class PlayerController : MonoBehaviour
{   
    public float jumpForcePlayer;
    public Animator animPlayer;
    public bool isGrounded = false ;
    public bool gameOver = false;
    public GameObject powerupIndicators;
    public bool hasPowerUp;

    private Rigidbody rbPlayer;
    private GameManager gameManager;
    private const string banner = "ca-app-pub-3435181233094974/4332021626";
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        animPlayer = GetComponent<Animator>();             
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        BannerView bannerView = new BannerView(banner, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
    void Update()
    {       
        JumpPlayer();        
    }   
     void JumpPlayer()
    {    
        if (Input.GetMouseButtonUp(0) && isGrounded && !gameOver)
        {
            rbPlayer.AddForce(Vector3.up * jumpForcePlayer, ForceMode.Impulse);
            
            isGrounded = false;
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("improvement"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCounDownRounTime());
            powerupIndicators.gameObject.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {           
            isGrounded = true;
        } 
        else if (collision.gameObject.CompareTag("Obstacle") )
        {
            gameOver = true;         
            animPlayer.SetBool("Death_b" , true);
            animPlayer.SetInteger("DeathType_int",1);
            gameManager.GameOver();
            Debug.Log("Game Over!");
            AdGameOver();
        }      
    }
    public void AdGameOver()
    {
        InterstitialAd interstitialAd = new InterstitialAd("ca-app-pub-3435181233094974/7888123253");
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
        if (interstitialAd.IsLoaded()) interstitialAd.Show();
    }
    IEnumerator PowerupCounDownRounTime()
    {
        yield return new WaitForSeconds(5);
        powerupIndicators.gameObject.SetActive(false);
        hasPowerUp = false;
    }
}
