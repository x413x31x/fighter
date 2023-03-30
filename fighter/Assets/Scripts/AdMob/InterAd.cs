using UnityEngine;
using GoogleMobileAds.Api;

public class InterAd : MonoBehaviour
{
    private InterstitialAd _interstitialAd;
    private string _adUnitId = "ca-app-pub-3940256099942544/8691691433";

    private void Awake()
    {
        LoadInterstitionalAd();
    }

    public void LoadInterstitionalAd()
    {
        if(_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }
        var adRequest = new AdRequest.Builder().Build();
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    return;
                }
                _interstitialAd = ad;
            });
    }

    public void ShowAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();
        }
    }
}
