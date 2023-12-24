using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static void playLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public static void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
