using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public static float pointCount; //Number of points the player has
    public float clickValue = 1.0f; //Number of points the player gets per click
    public float passiveClick = 1.0f;
    public GameObject pointDisplayObject; //Display point object
    public TMP_Text pointDisplayText;

    public float timer = 1.0f;

    [SerializeField]
    public float clickValueUpgradeCost = 100.0f;
    public float passiveClickUpgradeCost = 100.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //clickValue = 1.0f;
        pointDisplayText = pointDisplayObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Click();
        PassiveIncrease();

        pointDisplayText.text = pointCount.ToString();
    }

    #region Standard Functions
    public void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointCount += clickValue;
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
