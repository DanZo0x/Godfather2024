using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] _pv;

    private void Awake()
    {
        _pv = new GameObject[transform.childCount];

        for (int i = 0; i < _pv.Length; i++)
        {
            _pv[i] = transform.GetChild(i).gameObject;
        }
    }

    public void updatelife(int vie)
    {
        for (int i = 0; i < _pv.Length; i++)
        {
            if (i < vie)
            {
                _pv[i].SetActive(true);
            }
            else
            {
                _pv[i].SetActive(false);
            }
        }
    }
}
