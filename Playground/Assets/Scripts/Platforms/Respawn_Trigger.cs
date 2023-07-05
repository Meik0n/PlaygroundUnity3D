using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Trigger : MonoBehaviour
{

    [SerializeField]
    private Transform m_spawn_point = null;


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController char_controller = other.GetComponent<CharacterController>();

            if (char_controller)
            {
                char_controller.enabled = false;
            }

            other.transform.position = m_spawn_point.position;

            if (char_controller)
            {
                char_controller.enabled = true;
            }
        }
    }
}
