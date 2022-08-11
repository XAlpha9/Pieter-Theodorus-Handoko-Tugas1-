using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OrganicObject : MonoBehaviour, IObject
{
    protected WaveSpawn Spawning;
    protected GameManager game;

    protected virtual void Start()
    {
        game = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        Move();
    }


    protected virtual void Move()
    {
        Vector2 VSpeed;
        VSpeed = new Vector2(game.SPDx, game.SPD);
        Rigidbody2D Rig = GetComponent<Rigidbody2D>();
        Rig.velocity = VSpeed;
    }

    public virtual void OnTap()
    {
        
    }
}
