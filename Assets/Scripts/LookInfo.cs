using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookInfo : MonoBehaviour
{
    private Camera camera;
    public float maxDistance = 5f;
    public TextMeshProUGUI prompt;
    public GameObject lookedObject;
    public ItemObject itemObject;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInfo()
    {
        //���̸� ���ϴ� - �˸��� ���̾ �¾Ҵ��� ���ϴ� - ������ ������ ���ϴ�
        Ray ray = camera.ScreenPointToRay(new Vector3 (Screen.width/2, Screen.height/2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, LayerMask.GetMask("LookInfo")))
        {
            lookedObject = hit.collider.gameObject;
            itemObject.itemData = hit.collider.gameObject.GetComponent<ItemData>();
            SetPrompt();
        }
    }

    public void SetPrompt()
    {
        prompt.gameObject.SetActive(true);
        prompt.text = itemObject.ItemInfo();
    }
}
