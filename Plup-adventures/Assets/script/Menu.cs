using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }
}
