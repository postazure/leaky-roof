using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    const int AUDIO_TITLE = 0;
    const int AUDIO_INTRO = 1;
    const int AUDIO_STAGE1 = 2;
    const int AUDIO_TRANSITION_TO_2 = 3;
    const int AUDIO_STAGE2 = 4;
    const int AUDIO_TRANSITION_TO_3 = 5;
    const int AUDIO_STAGE3 = 6;
    const int AUDIO_FINISHED = 7;

    const int SCENE_TITLE = 0;
    const int SCENE_INSTRUCTIONS = 1;
    const int SCENE_MAIN = 2;
    const int SCENE_GAMEOVER = 3;

    private AudioSource[] audioSources;
    private int currentScore;

    private static SceneController _instance;
    public static SceneController instance { get { return _instance; } }

    private void Awake()
    {
        // Singleton
        if (_instance == null)
        {
            _instance = this;
            audioSources = GetComponents<AudioSource>();
            foreach (AudioSource audioSource in audioSources)
            {
                Debug.Log("Audio: " + audioSource.clip.name);
            }
            audioSources[AUDIO_TITLE].Play();
            ScoreController scoreController = ScoreController.instance;
            if (scoreController != null)
            {
                currentScore = scoreController.GetTotalScore();
            }
        }
        else
        {
            Destroy(this);
        }

    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        switch (nextSceneIndex)
        {
            case SCENE_MAIN:
                Debug.Log("Stop Title music, Play intro, followed by Stage 1");
                StopAll();
                audioSources[AUDIO_INTRO].Play();
                audioSources[AUDIO_STAGE1].PlayDelayed(audioSources[AUDIO_INTRO].clip.length);
                break;
            case SCENE_GAMEOVER:
                Debug.Log("Stop any music, play Finished track");
                StopAll();
                //audioSources[AUDIO_FINISHED].Play();
                break;
        }
    }

    void StopAll()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            Debug.Log("Stopping Audio: " + audioSource.clip.name);
            audioSource.Stop();
        }
    }

    public void ScoreDidChange(int newScore)
    {
        Debug.Log("currentScore = " + currentScore + ", newScore=" + newScore);
        if (currentScore == 0 && newScore > 0)
        {
            //// transition to stage 2
            Debug.Log("Stop any music, transition to Stage 2");
            StopAll();
            audioSources[AUDIO_TRANSITION_TO_2].Play();
            audioSources[AUDIO_STAGE2].PlayDelayed(audioSources[AUDIO_TRANSITION_TO_2].clip.length);
        }
        else if (currentScore < 700 && newScore >= 700)
        {
            Debug.Log("Stop any music, transition to Stage 3");
            StopAll();
            audioSources[AUDIO_TRANSITION_TO_3].Play();
            audioSources[AUDIO_STAGE3].PlayDelayed(audioSources[AUDIO_TRANSITION_TO_3].clip.length);
        }
        currentScore = newScore;
    }
}
