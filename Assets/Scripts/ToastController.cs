using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastController : MonoBehaviour
{
    public int toastDurationInSeconds;

    private Text toastText;
    private double? toastTimeStart;
    private List<string> messageQueue = new List<string>();

    public void PublishToast(string message)
    {
        messageQueue.Add(message);
    }

    private void Start()
    {
        toastText = GetComponent<Text>();
        toastText.text = "";
    }

    private void Update()
    {
        if (toastTimeStart != null)
        {
            if (Time.fixedTime - toastTimeStart > toastDurationInSeconds)
            {
                toastText.text = "";
                toastTimeStart = null;
            }
        }
        else if (messageQueue.Count > 0)
        {
            string message = messageQueue[0];
            messageQueue.RemoveAt(0);

            SetMessage(message);
        }

    }

    private void SetMessage(string message)
    {
        toastText.text = message;
        toastTimeStart = Time.fixedTime;
    }

}
