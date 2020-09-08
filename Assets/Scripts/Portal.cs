using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int enemiesCount;
    private GameObject[] _enemies;
    private Vector3 _start;

    void Start()
    {
        GameObject child = transform.GetChild(1).gameObject;
        
        _enemies = new GameObject[enemiesCount];
        _enemies[0] = child;
        
        for (int i = 1; i < enemiesCount; i++)
        {
            _enemies[i] = Instantiate(child, child.transform.position, child.transform.rotation);
            _enemies[i].transform.localScale = child.transform.lossyScale;
            _enemies[i].transform.parent = gameObject.transform;
            _enemies[i].SetActive(false);
        }

        _start = child.transform.localPosition;
    }

    public void StartSpawn()
    {
        StartCoroutine(nameof(Spawn));
    }

    public void StopSpawn()
    {
        StopCoroutine(nameof(Spawn));

        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(false);
        }
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < enemiesCount; i++)
            {
                GameObject enemy = _enemies[i];
                
                if (enemy.activeInHierarchy) 
                    continue;

                enemy.transform.localPosition = _start;
                enemy.SetActive(true);
                break;
            }
            
            yield return new WaitForSeconds(2);
        }
    }
}
