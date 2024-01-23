using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float _treeHealth;
    [SerializeField] private Animator _anim;

    [SerializeField] private GameObject _woodPrefab;
    [SerializeField] private ParticleSystem _leafs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHit()
    {
        _treeHealth--;
        _anim.SetTrigger("isHit");
        _leafs.Play();

        if (_treeHealth == 0)
        {
            for (var i = 0; i < Random.RandomRange(1, 4); i++)
                Instantiate(_woodPrefab, transform.position + new Vector3(Random.RandomRange(-0.5f, 0.5f), Random.RandomRange(-0.5f, 0.5f), 0f), transform.rotation);

            _anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && _treeHealth > 0)
            OnHit();
    }
}
