using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public GameObject zombie;
    public int zombieCount;

    public GameObject zombieBoss;
    public int zombieBossCount;

    public TextMeshProUGUI WaveText;
    public int WaveNumb;

    public float waveTimer = 30f;
    public bool waveTimerOn;

    void Start()
    {
        if (zombie != null && zombieBoss != null)
        {
            waveTimerOn = true;  
            WaveText.text = "Wave: 1";
            WaveNumb = 1;
        }
    }
    void Update()
    {
        if (waveTimerOn == true)
        {
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0f)
            {
                waveTimer = 30f;
                WaveNumb++;
                WaveText.text = "Wave: " + WaveNumb.ToString();
                SpawnZombies();
            }
        }
    }

    void SpawnZombies()
    {
        for (int i = 0; i < WaveNumb; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
            Instantiate(zombie, spawnPosition, Quaternion.identity);
        }
        if (WaveNumb % 10 == 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10f), 0f, Random.Range(-10, 10f));
            Instantiate(zombieBoss, spawnPosition, Quaternion.identity);
        }
    }
}
