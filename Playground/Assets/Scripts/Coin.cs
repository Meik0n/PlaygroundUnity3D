using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 5.0f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, m_speed * Time.deltaTime));
    }


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ++other.gameObject.GetComponent<Player>().Coins;

            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            this.enabled = false;
        }
    }
}
