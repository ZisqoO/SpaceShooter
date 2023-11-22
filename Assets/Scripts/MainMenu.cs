using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static MainMenu instance = null;
    public static MainMenu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MainMenu>();
            }
            return instance;
        }
    }
    public void SceneChanger(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }
    
}
