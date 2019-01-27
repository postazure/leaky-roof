using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneAdvance : MonoBehaviour
{

    public int delayInSeconds;
    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > delayInSeconds)
        {
            SceneController.instance.LoadNextScene();
        }
    }
}
