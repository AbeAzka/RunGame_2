using UnityEngine;
using UnityEngine.Advertisements;
using System;
using System.Collections;

public class AdsInitializer : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    string gameId = "5095576";
#else
    string gameId = "5095577";
#endif

    Action OnRewardedAdSuccess;
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void PlayerRewardedAd(Action onSuccess)
    {
        OnRewardedAdSuccess = onSuccess;
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded ad is not ready!");
        }
;
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADS ARE READY!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("VIDEO STARTED");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            OnRewardedAdSuccess.Invoke();
        }
    }
}