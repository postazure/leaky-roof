using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastController : MonoBehaviour
{
    public int toastDurationInSeconds;

    public Image toastIcon;
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
    private List<Toast> toastQueue = new List<Toast>();

    private void Start()
    {
        toastContainer.SetActive(false);
    }

    public void PublishToast(string message)
    {
        var toast = new Toast { description = message };
        toastQueue.Add(toast);
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
        toastQueue.Add(toast);
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
        else if (toastQueue.Count > 0)
        {
            var toast = toastQueue[0];
            toastQueue.RemoveAt(0);
            DisplayToast(toast);
        }

    }

    private void DisplayToast(Toast toast)
    {
        toastContainer.SetActive(true);

        // Handle Icon
        if (toast.icon == null)
        {
            toastIcon.gameObject.SetActive(false);
        }
        else
        {
            toastIcon.gameObject.SetActive(true);
            toastIcon.sprite = toast.icon;
        }

        // Handle score
        if (string.IsNullOrEmpty(toast.score))
        {
            score.gameObject.SetActive(false);
        }
        else
        {
            score.gameObject.SetActive(true);
           score.text = toast.score;
        }

        description.text = toast.description;
        toastTimeStart = Time.fixedTime;
    }

}
