using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_platform : MonoBehaviour
{

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.Activate_Poison();
        }
    }


    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Desactivate_Poison();
            player.Activate_Regen();
        }

    }
}
