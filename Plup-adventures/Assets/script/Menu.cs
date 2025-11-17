using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private float savedVolume = 1f; // salva o volume antes do mute

    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void nogame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ActiveConfig(GameObject go)
    {
        go.SetActive(true);
    }

    public void DisableConfig(GameObject go)
    {
        go.SetActive(false);
    }

    public void ActivePause(GameObject go)
    {
        Time.timeScale = 0;
        go.SetActive(true);
    }

    public void DisablePause(GameObject go)
    {
        Time.timeScale = 1;
        go.SetActive(false);
    }

    // ---------------------------
    //      🔊 Funções de Áudio
    // ---------------------------

    // Mute: zera o volume e salva volume anterior
    public void Mute()
    {
        savedVolume = AudioListener.volume; // guarda o volume atual
        AudioListener.volume = 0f;          // desliga o som
    }

    // Unmute: volta o volume salvo
    public void Unmute()
    {
        AudioListener.volume = savedVolume; // restaura o volume original
    }
}
