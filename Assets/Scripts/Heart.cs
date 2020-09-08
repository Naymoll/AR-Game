using UnityEngine;

public class Heart : MonoBehaviour
{
    public int health;
    private int _baseHealth;

    private void Start()
    {
        _baseHealth = health;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;

        if (!otherGameObject.CompareTag("Enemy")) 
            return;
        
        otherGameObject.SetActive(false);
        
        health -= 25;
    }

    public void RestoreHealth()
    {
        health = _baseHealth;
    } 
}
