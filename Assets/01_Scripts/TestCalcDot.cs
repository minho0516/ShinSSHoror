using UnityEngine;

public class TestCalcDot : MonoBehaviour
{
    [SerializeField] private Transform playerTrm;
    void FixedUpdate()
    {
        float dir = Vector3.Dot(playerTrm.forward, transform.forward);
        Debug.Log(dir);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 20);
        Gizmos.color = Color.green;
    }
}
