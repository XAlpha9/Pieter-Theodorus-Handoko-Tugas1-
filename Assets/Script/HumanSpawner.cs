using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : WaveSpawn
{
    private GameObject Human;
    float HumanTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Human = GameObject.Find("Human");
        HumanTime = Random.Range(3f, 6f);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(game.isFinish == false)
        {
            if (HumanTime > 0)
            {
                HumanTime = HumanTime - Time.deltaTime;
            }

            else if (HumanTime <= 0)
            {
                Spawn();
            }
        }
    }
    protected override void Spawn()
    {
        Instantiate(Human, new Vector2(Random.Range(transform.position.x - 8, transform.position.x + 8), transform.position.y+6), Quaternion.identity, transform);
        HumanTime = Random.Range(3f, 6f);
    }

    
}
