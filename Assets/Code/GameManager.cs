using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Config Parallax")]
    public float speed;

    [Header("Config MoveGround")]
    public SpriteRenderer[] individalPlatform;
    public GameObject[] groundRange;
    public GameObject[] assets;

    public float widthGround;
    public float toDestroy;
    public float groundVel;
    public int platformCont=0;

    public float posToSet;

    [Header("SetaObstaculos config")]
    public GameObject[] obstacles;
    public int objects;


    [Header("Points")]
    public int pointInt;
    public Text pointText;

    [Header("Player conf")]
    public float isfallenToGameOver;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SceneToLod(string name)
    {
        SceneManager.LoadScene(name);
    }


    public void OnApplicationQuit()
    {
        OnApplicationQuit();
    }

}
