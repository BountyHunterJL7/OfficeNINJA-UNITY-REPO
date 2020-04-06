using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("_last_scene_"));
        
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
