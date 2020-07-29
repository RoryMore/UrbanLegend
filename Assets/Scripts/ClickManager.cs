using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public static float pointCount; //Number of points the player has
    public float clickValue = 1.0f; //Number of points the player gets per click
    public float shortTermProgress = 0.0f; //Number from 1-100 that spawns things
    public float passiveClick = 1.0f;
    public float timer = 1.0f;

    //References to game objects
    public GameObject pointDisplayObject; //Display point object
    public TMP_Text pointDisplayText;
    public Slider progressBar;
    public NotificationSwap notification;
    

    [SerializeField]
    public float clickValueUpgradeCost = 100.0f;
    public float passiveClickUpgradeCost = 100.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //clickValue = 1.0f;
        pointDisplayText = pointDisplayObject.GetComponent<TMP_Text>();
        progressBar.value = shortTermProgress;
    }

    // Update is called once per frame
    void Update()
    {
        Click();
        CheckUpgradeProgress();
        PassiveIncrease();

        pointDisplayText.text = Mathf.Round(pointCount).ToString();
    }

    #region Standard Functions
    public void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointCount += clickValue;
            AddProgress();
            //Display rounded down value
        }

        
    }

    public void PassiveIncrease()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            pointCount += passiveClick;
            timer = 1.0f;
        }
    }

    public void AddProgress()
    {
        shortTermProgress += 1;
        //Check Progress
        if (shortTermProgress >= 100)
        {
            //Spawn things then reset
            shortTermProgress = 0;
        }

        progressBar.value = shortTermProgress;
    }

    public void CheckUpgradeProgress()
    {
        if (pointCount >= clickValueUpgradeCost || pointCount >= passiveClickUpgradeCost)
        {
            notification.SwapSpriteToActive();
        }
        else
        {
            notification.SwapSpriteToInactive();
        }
    }


    #endregion

    #region Upgrades

    public void IncreaseClickValue()
    {
        if (pointCount >= clickValueUpgradeCost)
        {
            pointCount -= clickValueUpgradeCost;
            clickValueUpgradeCost *= 1.5f;
            clickValue += 0.5f;
        }
    }

    public void IncreasePassiveClick()
    {
        if (pointCount >= passiveClickUpgradeCost)
        {
            pointCount -= passiveClickUpgradeCost;
            passiveClickUpgradeCost *= 1.5f;
            passiveClick += 0.05f;
        }
    }
    #endregion
}
