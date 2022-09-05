using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPowerUp : ItemBase
{
    private float _attackPowerUp = 1;
    /// <summary>
    ///　攻撃アップのポーション獲得時のパーティカル
    /// </summary>
    private ParticleSystem _attackUpPartical;
    /// <summary>
    /// string"攻撃力up"
    /// </summary>
    [SerializeField] string _powerUP = "攻撃力UP";
    [SerializeField] Text _text;
    [SerializeField] GameObject text;

    void Start()
    {
        _attackUpPartical = GameObject.Find("model").GetComponent<ParticleSystem>();
        _attackUpPartical.Stop();
        _text.text = "";
        text.SetActive(false);
    }
   
    public override void Action()
    {
        FindObjectOfType<PlayerManager>().AttackPower(_attackPowerUp);
        
        StartCoroutine(AttackParticalTime());
        _text.text = _powerUP;
        _attackUpPartical.Play();
        text.SetActive(true);
    }
    // Start is called before the first frame update
    IEnumerator AttackParticalTime()
    {
        Debug.Log("A");
        yield return new WaitForSeconds(20);
        
        _attackUpPartical.Stop();
        _text.text = "";
        text.SetActive(false) ;
    }
    
}
