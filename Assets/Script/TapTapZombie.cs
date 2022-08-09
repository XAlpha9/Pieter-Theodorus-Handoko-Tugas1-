using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTapZombie : MonoBehaviour
{
    public static float Spd = -2;
    private Vector2 Vspeed;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        Vspeed.x = 0;
        Vspeed.y = Spd;
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vspeed;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        WaveSpawn.TotalZombie = WaveSpawn.TotalZombie - 1;
        Destroy(this.gameObject);
        WaveSpawn.score = WaveSpawn.score + 1;
        if (WaveSpawn.TotalZombie <= 0)
        {
            WaveSpawn.isFinish = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WaveSpawn.life = WaveSpawn.life - 1;
        WaveSpawn.TotalZombie = WaveSpawn.TotalZombie - 1;
        Destroy(this.gameObject);
    }
}
