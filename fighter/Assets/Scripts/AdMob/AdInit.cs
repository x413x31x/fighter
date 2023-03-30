using UnityEngine;
using GoogleMobileAds.Api;

public class AdInit : MonoBehaviour
{
    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
