using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke(nameof(Play), 2f);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }
}
