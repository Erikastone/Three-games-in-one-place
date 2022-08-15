using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour
{
    private const string banner = "ca-app-pub-3435181233094974/4332021626";

    private void Start()
    {
        BannerView bannerView = new BannerView(banner, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);     
    }   
}
