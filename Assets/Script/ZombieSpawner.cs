using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : WaveSpawn
{
    private GameObject Zombie;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Zombie = GameObject.Find("Zombie");

        Spawn();
    }


    // Update is called once per frame
    protected override void Update()
    {
        if (game.isFinish == false)
        {
            if (timeSpawn > 0)
            {
                timeSpawn = timeSpawn - Time.deltaTime;
            }

            else if (timeSpawn <= 0)
            {
                Spawn();
            }
        }
    }

    protected override void Spawn()
    {
        {
            Instantiate(Zombie, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
            if (game.Wave >= 10)
            {
                Instantiate(Zombie, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
                if (game.Wave >= 20)
                {
                    Instantiate(Zombie, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
                }
            }

            timeSpawn = TimeIncrement;
        }
    }

    protected void WaveIncrement()
    {
        MaxZombie += 2;
        game.TotalZombie = MaxZombie;
        game.Wave = game.Wave + 1;
        if (TimeIncrement >= 0.2)
        {
            TimeIncrement = TimeIncrement - 0.05f;
        }
        if (game.SPD >= -10)
        {
            game.SPD = game.SPD - 0.1f;
        }
        game.isFinish = false;
        game.NextWave.SetActive(false);
    }
}
