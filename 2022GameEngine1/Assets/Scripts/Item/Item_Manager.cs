using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    private static Item_Manager instance;
    public GameManager gManager;

    public float item_num;

    public bool once_call;
    // Start is called before the first frame update
    public static Item_Manager GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<Item_Manager>();
            if(instance == null)
            {
                GameObject container = new GameObject("Item_Manager");
                instance = container.AddComponent<Item_Manager>();
            }
        }
        return instance;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        gManager = GameManager.GetInstance();
        once_call = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.Item_Event && once_call)
        {
            choice_Item();
            once_call = false;
        }

        if (gManager.Item_Event == false && once_call == false)
        {
            once_call = true;
        }
    }

    public void choice_Item()
    {
        item_num = 0;
        switch (item_num)
        {
            case 0:
                add_Guard_Item();
                break;
            case 1:
                Heal_Health();
                break;
            case 2:
                debuff01();
                break;
            case 3:
                debuff02();
                break;
        }
    }
    public void add_Guard_Item()
    {
        gManager.playerstates.addGuard(1f);
        gManager.Item_time = 10f;
    }

    public void Heal_Health()
    {
        gManager.playerstates.Heal();
        gManager.Item_time = 10f;
    }
    public void debuff01()
    {
        gManager.Item_time = 0.1f;
    }
    public void debuff02()
    {
        gManager.Item_time = 0.2f;
    }
}
