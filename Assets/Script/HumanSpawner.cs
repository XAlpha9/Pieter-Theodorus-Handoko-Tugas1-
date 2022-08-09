using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    public GameObject Human;
    float HumanTime;

    // Start is called before the first frame update
    void Start()
    {
        HumanTime = Random.Range(3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if (HumanTime > 0)
        {
            HumanTime = HumanTime - Time.deltaTime;
        }
        else if (HumanTime <= 0)
        {
            HumanSpawn();
        }
    }
    public void HumanSpawn()
    {
        Instantiate(Human, new Vector2(Random.Range(-9, 9), 13f), Quaternion.identity);
        HumanTime = Random.Range(3f, 6f);
    }
}