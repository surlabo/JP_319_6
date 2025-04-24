using System;
using UnityEngine;
using UnityEngine.UI;

public class StartManuController : MonoBehaviour
{
    public static StartManuController Instance;
    [SerializeField] private Button startBtn;
    [SerializeField] private GameObject startManuPanel;
    [SerializeField] private GameObject inGamePanel;



    private void Start()
    {
        startBtn.onClick.AddListener(DeactivateStartManu);
    }

    private void DeactivateStartManu()
    {
        startManuPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }
 
}

