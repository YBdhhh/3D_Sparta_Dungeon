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

    //�ð��� ���� ��Ű� �پ��
    //0�� �Ǹ� �ǰ� �޾ƿ�
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
