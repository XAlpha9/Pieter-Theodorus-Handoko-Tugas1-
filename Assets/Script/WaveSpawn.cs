using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class WaveSpawn : MonoBehaviour
{
    protected OrganicObject organic;
    protected int MaxZombie = 10;
    protected float timeSpawn, TimeIncrement = 2f;
    protected GameManager game;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        game = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected abstract void Spawn();


}
