using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;

    private Rigidbody2D _rig;

    private float _initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;

    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool IsRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool IsRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _initialSpeed = _speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        _rig.MovePosition(_rig.position + _direction * _speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = _runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
            _speed = _runSpeed;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            _speed = _initialSpeed;
        }
    }

    #endregion
}
