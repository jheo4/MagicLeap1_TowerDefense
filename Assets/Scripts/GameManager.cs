using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public WaveManager waveManager;

    private static GameManager managerInstance; // for singleton

    public static GameManager instance
    {
        get
        {
            if(managerInstance == null)
            {
                GameManager manager = FindObjectOfType<GameManager>();
                if(manager == null)
                {
                    Debug.LogError("No instance of GameManager found in scene");
                }
                managerInstance = manager;
            }
            return managerInstance;
        }
    }

    void OnEnable()
    {
        player = FindObjectOfType<Player>();
        waveManager = FindObjectOfType<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.life <= 0)
        {
            SceneManager.LoadScene("LoseMenu");
        }
        else if(waveManager.currentWave > waveManager.maxWave)
        {
            SceneManager.LoadScene("WinMenu");
        }
    }

}
