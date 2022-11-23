using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IButton
{
    public void Push()
    {
        SceneManager.LoadScene("TowerDefense");
    }
}
