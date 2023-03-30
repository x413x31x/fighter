using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;

public class RewAd : MonoBehaviour
{
    private RewardedAd _rewardedAd;
    private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
    public UnityEvent<bool> OnAdWatched;

    private void Awake()
    {
        LoadRewardedAd();
    }

    public void LoadRewardedAd()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }
        var adRequest = new AdRequest.Builder().Build();
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    return;
                }
                _rewardedAd = ad;
            });
    }

    public void ShowAd(bool isGoldReward)
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) => { });
            LoadRewardedAd();
            OnAdWatched.Invoke(isGoldReward);
        }
    }
}
