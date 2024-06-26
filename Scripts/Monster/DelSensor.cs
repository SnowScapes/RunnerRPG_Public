using UnityEngine;

public class DelSensor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            other.transform.parent.gameObject.SetActive(false);
            other.transform.parent.parent = SpawnManager.instance.transform;
        }
    }
}
