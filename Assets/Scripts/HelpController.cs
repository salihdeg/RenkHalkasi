using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private bool _enabled = false;

    public void ShowOrHide()
    {
        TopKontrol.isStart = false;
        if (_enabled)
        {
            _enabled = false;
            _panel.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            _enabled = true;
            _panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
