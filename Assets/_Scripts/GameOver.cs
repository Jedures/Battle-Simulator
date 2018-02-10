using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;

public class GameOver : MonoBehaviour {
    public GameObject Panel;
    public Text text;
    public bool flag = true;
    public int i=0;
	// Use this for initialization
	void Start () {
        String appKey = "8ffa9955bb57e14bb37c40322552af3828505abfbf1e6dd6";
        Appodeal.disableLocationPermissionCheck();
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
    }

    // Update is called once per frame
    void Update()
    {
        GameOverCh();
    }
    public void GameOverCh()
    {
        GameObject[] warrior = GameObject.FindGameObjectsWithTag("Warrior");
        int cout1 = 0;
        int cout2 = 0;
        for (int i = 0; i < warrior.Length; i++)
        {
            if (warrior[i].GetComponent<AIController>()._isDeath == true)
            {
                cout1++;
            }
        }
        if (cout1 == warrior.Length && warrior.Length != 0)
        {

            Panel.SetActive(true);
            text.text = "Skelets are winners";
            if (MoneyStatic._fight == 1)
            {
                AddMoney(50);
            }
            else if (MoneyStatic._fight == 2) AddMoney(300);
        }
        else cout1 = 0;
        GameObject[] skelet = GameObject.FindGameObjectsWithTag("Skelet");
        for (int i = 0; i < skelet.Length; i++)
        {
            if (skelet[i].GetComponent<AIController>()._isDeath == true)
            {

                cout2++;
            }


        }
        if (cout2 == skelet.Length && skelet.Length != 0)
        {

            Panel.SetActive(true);
            text.text = "Warriors are winners";
            if (MoneyStatic._fight == 2)
            {
                AddMoney(50);

            }
            else AddMoney(300);
        }
        else cout2 = 0;
    }
    public void AddMoney(int amount)
    {

        if (i == 0)
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
            Appodeal.isLoaded(Appodeal.REWARDED_VIDEO);
            MoneyStatic._Money += amount;
            i++;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
