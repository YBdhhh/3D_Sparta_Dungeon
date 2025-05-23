using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Condition : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public float maxHunger;
    public float curHunger;
    public float hungerDown;
    public float maxStamina;
    public float curStamina;
    public Image uiBar;

    //시간에 따라 헝거가 줄어요
    //0이 되면 피가 달아요
    public void HungerDown()
    {
        curHunger -= hungerDown * Time.deltaTime;

        uiBar.fillAmount = curHunger/maxHunger;
    }
    void Start()
    {
        curHunger = maxHunger;
    }

    void Update()
    {
        
    }
}
