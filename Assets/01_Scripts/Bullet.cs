using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO dataSO;

    private void Update()
    {
        transform.Translate(Vector3.forward * dataSO.Speed * Time.deltaTime);
    }
}
