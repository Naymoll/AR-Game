using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Portal[] portals;
    public Heart heart;
    
    private bool _started;
    
    void Start()
    {
        _started = false;
    }

    private void Update()
    {
        if (!_started)
            return;

        if (heart.health > 0)
            DetectEnemy();
        else
            StopGame();
    }

    public void StartGame()
    {
        foreach (var portal in portals)
        {
            portal.StartSpawn();
        }
        
        _started = true;
    }

    public void StopGame()
    {
        foreach (var portal in portals)
        {
            portal.StopSpawn();
        }

        _started = false;

        heart.RestoreHealth();
    }

    private void DetectEnemy()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    GameObject enemy = raycastHit.transform.gameObject;

                    if (enemy.CompareTag("Enemy"))
                    {
                        enemy.SetActive(false);
                    }
                }
            }
        }
#endif
        
#if UNITY_STANDALONE
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                GameObject enemy = raycastHit.transform.gameObject;

                if (enemy.CompareTag("Enemy"))
                {
                    enemy.SetActive(false);
                }
            }
        }
#endif
    }
}
