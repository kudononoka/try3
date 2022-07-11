using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrunk : MonoBehaviour
{
    private Transform _player;
    private Animator _anim;
    private float _maxHp = 3f;
    public float _nowHp;
    [SerializeField] GameObject _bullet;
    private float _attackInterval;
    private float _attack = 2.5f;
    private float _damage = 1;
    private PlayerManager _playerManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        _anim = GetComponent<Animator>();
        _nowHp = _maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, _player.transform.position) < 8)
        {
            _attackInterval += Time.deltaTime;
            _anim.SetBool("attack",true);
            if (_attackInterval > _attack)
            {
                Instantiate(_bullet, new Vector2(transform.position.x - 1, transform.position.y - 0.1f), Quaternion.identity);
                _attackInterval = 0;    
            }
        }
        else
        {
            _anim.SetBool("attack",false);
        }
        
    }

    private void Hp(float damage)
    {
        _nowHp = _nowHp - damage;
        if(_nowHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("SwordAttack"))
        {
            Debug.Log("s");
            Hp(_playerManager._attackPower);
        }
    }


}
