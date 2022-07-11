using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUp : ItemBase
{
    private float _attackPowerUp = 1;
    public override void Action()
    {
        FindObjectOfType<PlayerManager>().AttackPower(_attackPowerUp);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
