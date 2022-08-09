using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawn : MonoBehaviour
{
    public GameObject Zombie;
    int MaxZombie, MaxHuman;
    float timeSpawn, TimeIncrement = 2f;
    public GameObject NextWave, GameOver;
    public Text ScoreTxT, LifeTxT;
    public static bool isFinish = false, IsDead = false;
    public static int TotalZombie = 10, Wave = 1, score = 0, life = 5;
    // Start is called before the first frame update
    void Start()
    {
        MaxZombie = TotalZombie;
        //MaxHuman = TotalHuman;
        ZombieSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxT.text = "score: " + score;
        LifeTxT.text = "" + life;

        if (isFinish == true)
        {
            NextWave.SetActive(true);
        }

        else if (IsDead == true || life == 0)
        {
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
        Instantiate(Zombie, new Vector2(Random.Range(-9, 9), 7), Quaternion.identity);
        if (Wave >= 10)
        {
            Instantiate(Zombie, new Vector2(Random.Range(-9, 9), 7), Quaternion.identity);
            if (Wave >= 20)
            {
                Instantiate(Zombie, new Vector2(Random.Range(-9, 9), 7), Quaternion.identity);
            }
        }

        timeSpawn = TimeIncrement;
    }

    public void WaveIncrement()
    {
        TotalZombie = MaxZombie;
        TotalZombie = TotalZombie + 2;
        //TotalHuman = MaxHuman;
        //TotalHuman = TotalHuman + 1;
        Wave = Wave + 1;
        if (TimeIncrement >= 0.2)
        {
            TimeIncrement = TimeIncrement - 0.05f;
        }
        if (TapTapZombie.Spd >= -10)
        {
            TapTapZombie.Spd = TapTapZombie.Spd - 0.1f;
        }
        Debug.Log("Zombie SPD: " + TapTapZombie.Spd);
        Debug.Log("Wave " + Wave);
        Debug.Log("Total Zombie: " + TotalZombie);
        Debug.Log("Time Spawn: " + TimeIncrement);
        isFinish = false;
        NextWave.SetActive(false);
        Start();
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
        SceneManager.LoadScene("Main");
        //Application.LoadLevel(Application.loadedLevel);
    }
}
