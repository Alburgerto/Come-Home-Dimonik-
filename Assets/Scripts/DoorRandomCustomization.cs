using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRandomCustomization : MonoBehaviour
{
    public int m_maxDetails; // Amount of detail sprites adorning door
    public SpriteRenderer[] m_details;

    void Start()
    {
        DisableDetails();
    }

    private void DisableDetails()
    {
        int details = Random.Range(1, m_maxDetails + 1);
        int detailsToDisable = m_details.Length - details;
        int disabledDetail;
        int i = 0;
        while (i < detailsToDisable)
        {
            disabledDetail = Random.Range(0, detailsToDisable + 1);
            if (m_details[disabledDetail].gameObject.activeSelf)
            {
                m_details[disabledDetail].gameObject.SetActive(false);
                ++i;
            }
        }
    }
}
