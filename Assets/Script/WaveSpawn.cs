using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawn : MonoBehaviour
{
    public GameObject Zombie;
    int MaxZombie = 10, MaxHuman;
    float timeSpawn, TimeIncrement = 2f;
    public GameObject NextWave, GameOver;
    public Text ScoreTxT, LifeTxT, WaveTxT, RemainingTxT;
    public static bool isFinish = false, IsDead = false;
    public static int TotalZombie = 10, Wave = 1, score = 0, life = 5;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
        ZombieSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxT.text = "score: " + score;
        LifeTxT.text = "" + life;
        WaveTxT.text = "Wave: " + Wave;
        RemainingTxT.text = "" + TotalZombie;
        if (isFinish == true)
        {
            DeleteAll();
            NextWave.SetActive(true);
        }

        else if (IsDead == true || life <= 0)
        {
            life = 0;
            DeleteAll();
            GameOver.SetActive(true);
        }

        else if (timeSpawn > 0)
        {
            timeSpawn = timeSpawn - Time.deltaTime;
        }

        else if(timeSpawn <= 0)
        {
            ZombieSpawn();
        }
        
        
    }

    public void ZombieSpawn()
    {
        Instantiate(Zombie, new Vector2(Random.Range(transform.position.x-8,transform.position.x+8), transform.position.y), Quaternion.identity, transform);
        if (Wave >= 10)
        {
            Instantiate(Zombie, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
            if (Wave >= 20)
            {
                Instantiate(Zombie, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
            }
        }

        timeSpawn = TimeIncrement;
    }

    public void WaveIncrement()
    {
        MaxZombie += 2;
        TotalZombie = MaxZombie;
        Wave = Wave + 1;
        if (TimeIncrement >= 0.2)
        {
            TimeIncrement = TimeIncrement - 0.05f;
        }
        if (TapTapZombie.Spd >= -10)
        {
            TapTapZombie.Spd = TapTapZombie.Spd - 0.1f;
        }
        isFinish = false;
        NextWave.SetActive(false);
    }

    public void Restart()
    {
        GameOver.SetActive(false);
        TotalZombie = 10;
        life = 5;
        score = 0;
        Wave = 1;
        IsDead = false;
        isFinish = false;
    }

    public void DeleteAll()
    {
        foreach(Transform Child in transform)
        {
            GameObject.Destroy(Child.gameObject);
        }
    }
}
