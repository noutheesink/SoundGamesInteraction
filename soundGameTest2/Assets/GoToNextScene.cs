using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    private AudioSource _audioSource;
    public int sceneNumber = 0;
    public float nextWaitTime = 8;
    public float nextSpawnDistance = 20;
    public float nextGamePlayTime = 30;
    public string nextScene = "GamePlayScene";
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.SetFloat("nextWaitTime", nextWaitTime);
        PlayerPrefs.SetFloat("nextSpawnDistance", nextSpawnDistance);
        PlayerPrefs.SetFloat("nextGamePlayTime", nextGamePlayTime);
        PlayerPrefs.SetInt("currentScene",sceneNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_audioSource.isPlaying) SceneManager.LoadScene(nextScene);
    }
}
