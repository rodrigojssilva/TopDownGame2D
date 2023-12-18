using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player _player;
    private Animator _anim;

    private void Start()
    {
        _player = GetComponent<Player>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if (_player.Direction.sqrMagnitude > 0)
        {
            if (_player.IsRolling)
                _anim.SetTrigger("isRoll");
            else
                _anim.SetInteger("transition", 1);
        }
        else
            _anim.SetInteger("transition", 0);

        if (_player.Direction.x > 0)
            transform.eulerAngles = new Vector2(0, 0);
        if (_player.Direction.x < 0)
            transform.eulerAngles = new Vector2(0, 180);
    }

    void OnRun()
    {
        if (_player.IsRunning)
            _anim.SetInteger("transition", 2);
    }

    #endregion
}
