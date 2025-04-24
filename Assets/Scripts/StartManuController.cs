using UnityEngine;

public class StartManuController : MonoBehaviour
{
    [SerializeField] private GameObject startManuPanel;


    public void DeactivateStartManu()
    {
        startManuPanel.SetActive(false);
    }
}
