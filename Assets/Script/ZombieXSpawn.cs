using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieXSpawn : WaveSpawn
{
    private GameObject ZombieX;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ZombieX = GameObject.Find("ZombieX");

        Spawn();
    }

    protected override void Update()
    {
        if (game.isFinish == false && game.Wave >= 3)
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
            Instantiate(ZombieX, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
            if (game.Wave >= 10)
            {
                Instantiate(ZombieX, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
                if (game.Wave >= 20)
                {
                    Instantiate(ZombieX, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y), Quaternion.identity, transform);
                }
            }

            timeSpawn = TimeIncrement;
        }
    }
}
