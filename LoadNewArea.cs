using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNewArea : MonoBehaviour
{
    public string LevelToLoad;
    public bool inBox;
    Scene m_Scene;
    public string sceneName;
    public GameObject PlayerWithScripts;
    private Player playerScript;


    private void Start()
    {
        PlayerWithScripts = GameObject.Find("Player");
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        playerScript = PlayerWithScripts.GetComponent<Player>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inBox = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inBox = false;
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && inBox == true && playerScript.RoomWalkCD == 0)
        {                       
            SceneManager.LoadScene(LevelToLoad);
        }
        
    }

}

