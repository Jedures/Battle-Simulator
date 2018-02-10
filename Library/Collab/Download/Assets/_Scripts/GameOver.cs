using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject Panel;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] warrior = GameObject.FindGameObjectsWithTag("Warrior");
        int cout1 = 0;
        int cout2 = 0;
        for (int i = 0; i< warrior.Length; i++)
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
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnController>()._fight == 1)
            {
                MoneyStatic._Money += 50;
            }
            else MoneyStatic._Money += 300;
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
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnController>()._fight == 2)
            {
                MoneyStatic._Money += 50;
            }
            else MoneyStatic._Money += 300;
        }
        else cout2 = 0; 
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
