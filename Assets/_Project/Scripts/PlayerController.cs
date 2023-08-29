using UnityEngine;

namespace DragonspiritGames
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 1f;
        
        PlayerControls _playerControls;
        Vector2 _movement;
        Rigidbody2D _rigidBody;

        void Awake()
        {
            _playerControls = new PlayerControls();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            PlayerInput();
        }
        void FixedUpdate()
        {
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
        }

        private void Move()
        {
            _rigidBody.MovePosition(_rigidBody.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
        }
    }

}
