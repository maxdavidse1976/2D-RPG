using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] float _moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _rigidbody.velocity = new Vector2(horizontal, vertical) * _moveSpeed;    
    }
}
