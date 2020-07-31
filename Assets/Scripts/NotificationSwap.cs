using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSwap : MonoBehaviour
{
    //public Image thisIm;
    public Sprite inactive;
    public Sprite active;
    

    public void SwapSpriteToActive()
    {

        this.GetComponent<Image>().sprite = active;

    }

    public void SwapSpriteToInactive()
    {
        this.GetComponent<Image>().sprite = inactive;
    }
}
