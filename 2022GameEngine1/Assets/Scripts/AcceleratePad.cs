using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratePad : MonoBehaviour
{
    public float force;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.GetInstance().TurnOnInvincible();
            var dir = other.GetComponent<PlayerMovement>().moveDir;
            other.attachedRigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
    }
}
