using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    VideoPlayer player;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += GotoMainMenu;
    }

    void GotoMainMenu(VideoPlayer vp) 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
