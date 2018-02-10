using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;

public  class _Money : MonoBehaviour {
    _Money IRewardedVideoAdListener;
    public Text _MoneyText;
	// Use this for initialization
	void Start () {
        String appKey = "8ffa9955bb57e14bb37c40322552af3828505abfbf1e6dd6";
        Appodeal.disableLocationPermissionCheck();
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
        MoneyStatic._Money = PlayerPrefs.GetInt("Money", MoneyStatic._Money);
	}
	
	// Update is called once per frame
	void Update () {
        _MoneyText.text = MoneyStatic._Money.ToString();
	}
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Money", MoneyStatic._Money);
    }
    public void AddGold()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
        Appodeal.isLoaded(Appodeal.REWARDED_VIDEO);

     //   MoneyStatic._Money += 50;
    }
    public void onRewardedVideoFinished(int amount, string name) { MoneyStatic._Money += 50; }
}

public static class MoneyStatic 
{
    public static int _Money = 100;
    public static int _fight = 0;
}

