using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Flowerhide : MonoBehaviour
{
    public MeshRenderer[] _MeshRenderers;
    public List<Material> _Materials;
    // Start is called before the first frame update
    void Start()
    {
        _MeshRenderers = GetComponentsInChildren<MeshRenderer>();
        if (_MeshRenderers.Length >= 0)
        {
            foreach (var meshRenderer in _MeshRenderers)
            {
                _Materials.Add(meshRenderer.material);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Item_Manager.GetInstance().item_num == 3 && GameManager.GetInstance().Item_Event == true)
            HideBuilding();
    }
    
    void HideBuilding()
    {
        if (_Materials.Count >= 0)
        {
            foreach (var _material in _Materials)
            {
                GameManager gameManager = GameManager.GetInstance();
                if ((gameManager.Pplayer.transform.position.z - transform.position.z) > -15 && (gameManager.Pplayer.transform.position.z - transform.position.z) <= 0)
                {
                    if (_material)
                    {
                        _material.DOFade(0, 0.2f);
                    }
                }
            }
        }
    }
}
