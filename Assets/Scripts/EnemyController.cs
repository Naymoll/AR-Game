using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<Heart>().transform;
    }

    private void Update()
    { 
        transform.position = Vector3.MoveTowards(transform.position, _target.position, 0.1f * Time.deltaTime);
    }
}
