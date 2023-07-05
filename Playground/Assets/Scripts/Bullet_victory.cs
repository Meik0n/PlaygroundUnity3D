using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_victory : MonoBehaviour
{
    [SerializeField]
    private float m_life_time = 3f;
    private float m_time_active;
    void Start()
    {
        m_time_active = 0f;
    }

    void OnEnable()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 10), Random.Range(0, 20), Random.Range(0, 10)), ForceMode.Impulse);
    }

    void Update()
    {
        m_time_active += Time.deltaTime;
        if (m_time_active >= m_life_time)
        {
            gameObject.SetActive(false);
            m_time_active = 0;
        }
    }
}
