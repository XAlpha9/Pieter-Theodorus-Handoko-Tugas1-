using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTapZombie : OrganicObject
{
    public override void OnTap()
    {
        Debug.Log("Total Zombie: "+ game.TotalZombie);
        game.TotalZombie = game.TotalZombie - 1;
        game.score = game.score + 1;
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
