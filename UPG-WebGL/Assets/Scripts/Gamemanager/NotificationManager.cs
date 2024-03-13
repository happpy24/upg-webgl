using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class NotificationManager : MonoBehaviour
{
    /// <summary>
    /// check if instance is not empty, then return it.
    /// </summary>
    public static NotificationManager Instance {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            instance = FindAnyObjectByType<NotificationManager>();            
            return instance;
        }
    }

    private static NotificationManager instance;
    /// <summary>
    /// set text and animate it
    /// </summary>
    [SerializeField] private TextMeshProUGUI notificationText;
    [SerializeField] private float fadeTime;

    private IEnumerator notificationCoroutine;

    public RectTransform notification; 


    public void SetNewNotification(string message)
    { 
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        notification.DOAnchorPos(new Vector3(0, 1550, 0), 0.5f);
        StartCoroutine(FadeOutNotification(message));
    }
    private IEnumerator FadeOutNotification(string message)
    {
        notificationText.text = message;
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            notificationText.color = new Color(notificationText.color.r,
                notificationText.color.g,
                notificationText.color.b,
                Mathf.Lerp(1f, 0f, t / fadeTime));
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

}