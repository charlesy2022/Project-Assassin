using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public string Scene;

    public void PlayGame()
    {
        SceneManager.LoadScene(Scene);
    }
}
