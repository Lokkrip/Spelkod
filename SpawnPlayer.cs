using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour {
    private Player Player;
    public Transform spawnPoint2;
    public Transform spawnPoint3;

    public string Room2;
    public string Room3;

    Scene m_Scene;
    public static string sceneName;


    // Use this for initialization
    void Awake()
    {
        
    }
    void Start () {

        Player = FindObjectOfType<Player>();
        


        if (sceneName == Room2)
        {
            Player.transform.position = spawnPoint2.position;
            
            
        }
        else if (sceneName == Room3)
        {
            Player.transform.position = spawnPoint3.position;
            

        }
        else
        {
            Player.transform.position = transform.position + new Vector3(0, 0, 0);
        }

        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

    }
}
