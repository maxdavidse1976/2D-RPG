using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator _playerAnimator;
    [SerializeField] float _moveSpeed;

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _rigidbody.velocity = new Vector2(horizontal, vertical) * _moveSpeed;
        _playerAnimator.SetFloat("moveX", _rigidbody.velocity.x);
        _playerAnimator.SetFloat("moveY", _rigidbody.velocity.y);

        if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1)
        {
            _playerAnimator.SetFloat("lastMoveX", horizontal);
            _playerAnimator.SetFloat("lastMoveY", vertical);
        }
    }
}
