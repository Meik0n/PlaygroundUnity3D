using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    private Player m_player;
    [SerializeField]
    private Transform m_spawn;

    private bool instantiating = false;
    void Start()
    {

    }


    void Update()
    {
        if (m_player.Coins == 5 && !instantiating)
        {
            StartCoroutine("Instantiate");
        }
    }

    private IEnumerator Instantiate()
    {
        instantiating = true;
        while (true)
        {
            GameObject bullet = Object_Pool.shared_instance.Get_Pooled_Object();
            if (bullet != null)
            {

                bullet.transform.position = m_spawn.position;
                bullet.SetActive(true);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
