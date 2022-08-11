using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public float SPD = -2, SPDx = 0;
    public GameObject NextWave;
    [SerializeField]
    private GameObject GameOver;
    public Text LifeTxT, WaveTxT, RemainingTxT;
    [SerializeField]
    private Text ScoreTxT;
    public bool isFinish = false, IsDead = false;
    public int TotalZombie = 10, Wave = 1, score = 0, life = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxT.text = "score: " + score;
        LifeTxT.text = "" + life;
        WaveTxT.text = "Wave: " + Wave;
        RemainingTxT.text = "" + TotalZombie;
        if (isFinish == true)
        {
            DeleteAll();
            NextWave.SetActive(true);
        }

        else if (IsDead == true || life <= 0)
        {
            life = 0;
            DeleteAll();
            GameOver.SetActive(true);
        }

        void DeleteAll()
        {
            foreach (Transform Child in transform)
            {
                GameObject.Destroy(Child.gameObject);
            }
        }
    }

    public void Restart()
    {
        GameOver.SetActive(false);
        TotalZombie = 10;
        life = 5;
        score = 0;
        Wave = 1;
        IsDead = false;
        isFinish = false;
        SPD = -2;
        SPDx = 0;
    }

    
}
