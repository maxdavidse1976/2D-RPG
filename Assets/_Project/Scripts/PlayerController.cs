using UnityEngine;

namespace DragonspiritGames
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 1f;
        
        PlayerControls _playerControls;
        Vector2 _movement;
        Rigidbody2D _rigidBody;
        Animator _animator;
        SpriteRenderer _spriteRenderer;

        void Awake()
        {
            _playerControls = new PlayerControls();
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            PlayerInput();
        }
        void FixedUpdate()
        {
            AdjustPlayerFacingDirection();
            Move();
        }

        void OnEnable()
        {
            _playerControls.Enable();   
        }

        void OnDisable()
        {
            _playerControls.Disable();
        }

        void PlayerInput()
        {
            _movement = _playerControls.Movement.Move.ReadValue<Vector2>();
            _animator.SetFloat("moveX", _movement.x);
            _animator.SetFloat("moveY", _movement.y);
        }

        private void Move()
        {
            _rigidBody.MovePosition(_rigidBody.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
        }

        void AdjustPlayerFacingDirection()
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
            if (mousePos.x > playerScreenPoint.x)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }    
        }
    }

}
