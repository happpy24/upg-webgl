using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responsive : MonoBehaviour
{
    [Header("Card holder rect transorm")]
    [SerializeField]private RectTransform cardHoldeRect = null;

    // Start is called before the first frame update
    void Start()
    {
        CheckSystem();
    }

    //checks what system the player is on and changes the anchor pos of the rect transform
    private void CheckSystem()
    {
        switch (SystemInfo.deviceType) 
        {

            case DeviceType.Handheld:
                cardHoldeRect.anchorMax = new Vector2(1, 1);
                break;

            case DeviceType.Desktop:

                //anchor min max
                cardHoldeRect.anchorMin = new Vector2(.5f, 0f);
                cardHoldeRect.anchorMax = new Vector2(.5f, 0f);

                cardHoldeRect.anchoredPosition += new Vector2(0, -162.0f);

                //set scale of rect transform
                cardHoldeRect.sizeDelta = new Vector2(785, 580);
                break;

        }
    }
}
