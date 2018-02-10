using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    
    #region vars
    public int _fight = 0;

    [Header("Камера")]
    public Camera camera;

    [Header("Prefabs")]
    public GameObject Warrior;
    public GameObject Skelet;
    #endregion
    
    #region UnityMethod

    void Update ()
    {
        SpawnPlayer();
	}

    #endregion

    #region Spawning

    public void SpawnEnemy()
    {
        GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag("Spawn");

        for (int i = 0; i < spawnpoints.Length; i++)
        {
            if (_fight == 1)
            {
                Instantiate(Skelet, spawnpoints[i].transform.position, Quaternion.identity);
            }
            else Instantiate(Warrior, spawnpoints[i].transform.position, Quaternion.identity);
        }
    }

    public void SpawnPlayer()
    {
#if UNITY_ANDROID
        if (Input.touches[0].phase == TouchPhase.Ended)
        {

            Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (_fight == 1)
                {
                    Instantiate(Warrior, hit.point, Quaternion.identity);
                }
                else
                {
                    Instantiate(Skelet, hit.point, Quaternion.identity);
                }
            }

        }

    
#endif  
        
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (_fight == 1)
                    Instantiate(Warrior, hit.point, Quaternion.identity);
                else Instantiate(Skelet, hit.point, Quaternion.identity);
            }
        }
#endif


    }

#endregion

#region UI

    public void SetActivWarrior()
    {
        _fight = 1;
    }
    public void SetActivePlayer()
    {
        _fight = 2;
    }

#endregion
}
