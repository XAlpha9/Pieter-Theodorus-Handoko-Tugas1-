using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTapHuman : OrganicObject
{
    private float spd = -1.05f;
    protected override void Move()
    {
        Vector2 VSpeed;
        VSpeed = new Vector2(game.SPDx, game.SPD + spd);
        Rigidbody2D Rig = GetComponent<Rigidbody2D>();
        Rig.velocity = VSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTap()
    {
        game.IsDead = true;
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        game.score = game.score + 5;
        Destroy(this.gameObject);
    }


}
