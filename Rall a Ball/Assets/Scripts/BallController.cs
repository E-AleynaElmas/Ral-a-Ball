using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Rigidbody physics;
    public int speed;
    int count;
    public int feedCount;
    public Text counter;
    public Text theEnd;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        count = 0;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(horizontal, 0, vertical);

        physics.AddForce(vec*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Feed")
        {
            Destroy(other.gameObject);
            count++;
            counter.text = "Score: " + count;

            if(count == feedCount)
            {
                theEnd.text = "Oyun Bitti";
            }
        }
    }
}
