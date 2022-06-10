using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCamera : MonoBehaviour
{
    public LayerMask _fieldLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraForwardRaycast();
    }
    
    void CameraForwardRaycast()
    {
        var ray = new Ray(transform.position, transform.forward);
        var maxDistance = 10f;
        // 광선 디버그 용도
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red);
        RaycastHit _raycastHit;
        var temp = Physics.Raycast(ray, out _raycastHit, maxDistance, _fieldLayer);
        if (temp)
        {
            _raycastHit.transform.GetComponent<Renderer>().sharedMaterial.DOFade(0.2f, 1);
        }
    }
}
