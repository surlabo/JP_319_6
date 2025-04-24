using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public static DeathController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Loss");
        SceneManager.LoadScene("SampleScene");
    }
}
