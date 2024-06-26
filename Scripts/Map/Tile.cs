using UnityEngine;

public class Tile : MonoBehaviour
{
    public int TileId;
    private float distance = -40f;

    private void Update()
    {
        transform.position -= Vector3.forward * TileManager.Instance.speed * Time.deltaTime;

        if (transform.position.z < distance)
        {
            gameObject.SetActive(false);
            TileManager.Instance.Release(TileId, gameObject);
            TileManager.Instance.SpawnTile();
        }
    }

}