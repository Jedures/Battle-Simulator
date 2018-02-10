using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class _Money : MonoBehaviour {
    
    public Text _MoneyText;
	// Use this for initialization
	void Start () {
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
        MoneyStatic._Money += 50;
    }
}
public static class MoneyStatic 
{
    public static int _Money = 100;
}

