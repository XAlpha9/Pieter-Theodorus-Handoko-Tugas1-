using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapXZombie : OrganicObject
{
    private float spdx = 9;
    protected override void Move()
    {
        Vector2 VSpeed;
        VSpeed = new Vector2(game.SPDx + spdx, game.SPD);
        Rigidbody2D Rig = GetComponent<Rigidbody2D>();
        Rig.velocity = VSpeed;
    }

    private void Update()
    {
        if (transform.position.x < -9 || transform.position.x > 9)
        {
            spdx *= -1;
            Move();
        }
    }

    public override void OnTap()
    {
        Debug.Log("Total Zombie: " + game.TotalZombie);
        game.TotalZombie = game.TotalZombie - 1;
        game.score = game.score + 10;
        Debug.Log("Score: " + game.score);
        if (game.TotalZombie <= 0)
        {
            game.isFinish = true;
        }
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        game.life = game.life - 1;
        game.TotalZombie = game.TotalZombie - 1;
        Destroy(this.gameObject);
    }
}
