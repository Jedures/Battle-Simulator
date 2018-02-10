using UnityEngine;

public class SpawnController : MonoBehaviour {
    
    #region vars

    public int _fight = 0;

    [Header("Камера")]
    public Camera camera;

    [Header("Prefabs")]
    public GameObject Warrior;
    public GameObject Skelet;

    private int countUnits = 0;

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

        for (int i = 0; i < countUnits; i++)
        {
            if (_fight == 1)
            {
                Instantiate(Skelet, spawnpoints[Random.Range(1, spawnpoints.Length)].transform.position, Quaternion.identity);
            }
            else Instantiate(Warrior, spawnpoints[Random.Range(1, spawnpoints.Length)].transform.position, Quaternion.identity);
        }
    }

    public void SpawnPlayer()
    {
#if UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.tag == "terrain")
                    {
                        if (_fight == 1)
                            Instantiate(Warrior, hit.point, Quaternion.identity);
                        else Instantiate(Skelet, hit.point, Quaternion.identity);

                        countUnits++;
                    }
                }
            }
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "terrain")
                {
                    if (_fight == 1)
                        Instantiate(Warrior, hit.point, Quaternion.identity);
                    else Instantiate(Skelet, hit.point, Quaternion.identity);

                    countUnits++;
                }
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
