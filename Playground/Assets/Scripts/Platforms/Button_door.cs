using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button_door : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_on_button_pressed = null;
    [SerializeField]
    private Collider m_trigger = null;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_on_button_pressed.Invoke();
            m_trigger.enabled = false;
        }

    }
}
