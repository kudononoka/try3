using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    [SerializeField] Ground _ground;
    private GameObject _model;
    private GameObject _sword;
    private BoxCollider2D _sword2;
    
    public float _time = 0f;
    public float _time2 = 0f;
    private GameObject _weapon;
    private float _walkSpeed = 80f;
    private float _jumpForce = 2500f;
    private float _maxHP = 200f;
    private float _nowHP = 200f;
    [SerializeField] Slider _hp;
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _canvas2;
    [SerializeField] List<GameObject> _item = new List<GameObject>();
    [SerializeField] Text _itemText;
    
    private bool isAttack = false;
    public float _attackPower = 1f;
    private ParticleSystem _recoveryPartical;
    
    // Start is called before the first frame update
    void Start()
    {
        _model = GameObject.Find("model");
        _rb = GetComponent<Rigidbody2D>();
        _anim = _model.GetComponent<Animator>();
        _recoveryPartical = GetComponent<ParticleSystem>();
        
        

        _sword = GameObject.Find("Sword");
        _sword2 = GameObject.Find("sword").GetComponent<BoxCollider2D>();
        
        _weapon = GameObject.FindWithTag("Sword");
        _sword.SetActive(false);
        _hp.maxValue = _maxHP;
        _hp.value = _nowHP;
        _sword2.enabled = false;
        _attackPower = 1f;
        _recoveryPartical.Stop();

       
        
    }

    // Update is called once per frame

    void LateUpdate()
    {
        GameObject item = _item.OrderBy(go => Vector3.Distance(go.transform.position, transform.position)).First().gameObject;
        Debug.Log(Vector3.Distance(item.transform.position, transform.position));
        if (Vector3.Distance(item.transform.position, transform.position) < 5)
        {
            _itemText.text = item.tag + "が近くにあるよ！";
        }
        else
        {
            _itemText.text = " ";
        }
        
                  

        
        _recoveryPartical.Stop();
        float x = Input.GetAxisRaw("Horizontal");
        if (_rb.velocity.magnitude < 5)
        {
            _rb.AddForce(Vector2.right * x * _walkSpeed);
        }

        if (Input.GetButtonDown("Jump") && _ground.isGround)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
            _anim.SetTrigger("jump");
        }



        if (x != 0)
        {
            _anim.SetFloat("run", _rb.velocity.magnitude);
            if (x == 1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (x == -1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            _anim.SetFloat("run", 0);
        }

        if(isAttack)
        {
            if (Input.GetKeyDown(KeyCode.Z) && _time == 0)
            {
                _time++;
                _anim.SetTrigger("attack");
            }
        }

        if (_time == 1)
        {
            
            _time2 += Time.deltaTime;
            if (_time2 < 0.55)
            {
               
                _sword2.enabled = true;
            }
            else
            {
                
                _sword2.enabled = false;
                _time = 0;
                _time2 = 0;
            }
        }
    }

    public void HP(float damage)
    {
        _hp.value = _hp.value - damage;
        if(_hp.value <= 0)
        {
            _anim.SetBool("die",true);
            _canvas2.SetActive(true);
        }
    }
    public void Recovery(float recovery)
    {
        _hp.value += recovery;
    }

    public void AttackPower(float attackPower)
    {
        _attackPower += attackPower;
    }
        


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Sword"))
        {
            Destroy(_weapon.gameObject);
            _sword.SetActive(true);
            isAttack = true;
        }
        if(other.gameObject.CompareTag("GameClear"))
        {
            _canvas.SetActive(true);
        }
        if(other.gameObject.CompareTag("GameOver"))
        {
            _canvas2.SetActive(true);
        }
        
    }
   
       
    




    

   
}
