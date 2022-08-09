using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTapHuman : MonoBehaviour
{
    private Vector2 Vspeed;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        Vspeed.x = 0;
        Vspeed.y = -1f + TapTapZombie.Spd;
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vspeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Destroy(this.gameObject);
        WaveSpawn.IsDead = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        WaveSpawn.score = WaveSpawn.score + 50;
    }
}
