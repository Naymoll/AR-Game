using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text healthText;
    
    public Heart heart;
    private int _health;
    
    void Start()
    {
        _health = heart.health;
        healthText.text = $"Health = {_health}";
    }
    
    void Update()
    {
        if (heart.health != _health)
        {
            _health = heart.health;
            healthText.text = $"Health = {_health}";
        }
    }
}
