using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastController : MonoBehaviour
{
    public float toastDurationInSeconds;

    public GameObject toastImageContainer;
    public Image toastImage;
    public TMPro.TextMeshProUGUI description;
    public TMPro.TextMeshProUGUI score;
    public GameObject toastContainer;

    struct Toast
    {
        public string description;
        public string score;
        public Sprite icon;
    }

    private double? toastTimeStart;
    private float defaultToastDuration;

    private void Start()
    {
        toastContainer.SetActive(false);
        defaultToastDuration = toastDurationInSeconds;
    }

    public void PublishToast(string message)
    {
        PublishToast(message, defaultToastDuration);
    }

    public void PublishToast(string message, float duration)
    {
        var toast = new Toast { description = message };
        DisplayToast(toast, duration);
    }


    public void PublishToast(string message, Sprite icon, int score)
    {
        // require a message for toast
        if (string.IsNullOrEmpty(message))
        {
            Debug.LogError("Toast requires a message/description. Non received.");
            return;
        }

        var toast = new Toast {
            description = message,
            icon = icon,
            score = score == 0 ? string.Empty : score.ToString()
        };

        float duration = score == 0 ? 1.5f : defaultToastDuration;

        DisplayToast(toast, duration);
    }
    
    public void PublishToast(SentimentalItem item)
    {
        PublishToast(item.description, item.image, item.value);
    }

    private void Update()
    {
        if (toastTimeStart != null)
        {
            if (Time.fixedTime - toastTimeStart > toastDurationInSeconds)
            {
                toastContainer.SetActive(false);
                toastTimeStart = null;
            }
        }
 
    }

    private void DisplayToast(Toast toast, float duration)
    {
        toastContainer.SetActive(true);
        toastDurationInSeconds = duration;

        // Handle Icon
        if (toast.icon == null)
        {
            toastImageContainer.SetActive(false);
        }
        else
        {
            toastImageContainer.SetActive(true);
            toastImage.sprite = toast.icon;
        }

        // Handle score
        if (string.IsNullOrEmpty(toast.score))
        {
            score.gameObject.SetActive(false);
        }
        else
        {
            score.gameObject.SetActive(true);
           score.text = "+ " + toast.score;
        }

        description.text = toast.description;
        toastTimeStart = Time.fixedTime;
    }

}
