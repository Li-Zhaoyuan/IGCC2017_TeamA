using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Status : MonoBehaviour {

    // all the status is now PUBLIC for debugging
    [Range(0,100)]
    public float health_point;
    [Range(0, 100)]
    public float energy_point;
    public float attack_point;
    public float speed_point;
    public float magic_point;
    public float luck_point;
    public float defence_point;
    // Use this for initialization
    void Start () {
		//TODO: Random stats

	}
	
	// Update is called once per frame
	void Update () {
		//TODO: mood to affect stats
	}

    //Setters
    public void SetAllRobotStatus(float att,float spd,float mag, float luk, float def )
    {
        attack_point = att;
        speed_point = spd;
        magic_point = mag;
        luck_point = luk;
        defence_point = def;
    }

    public void SetHealthPoint(float value)
    {
        health_point = value;
    }

    public void SetEnergyPoint(float value)
    {
        energy_point = value;
    }

    public void SetAttackPoint(float value)
    {
        attack_point = value;
    }

    public void SetSpeedPoint(float value)
    {
        speed_point = value;
    }

    public void SetMagicPoint(float value)
    {
        magic_point = value;
    }

    public void SetLuckPoint(float value)
    {
        luck_point = value;
    }

    public void SetDefencePoint(float value)
    {
        defence_point = value;
    }

    //Getters
    public float GetHealthPoint()
    {
        return health_point;
    }

    public float GetEnergyPoint()
    {
        return energy_point;
    }

    public float SetAttackPoint()
    {                            
        return attack_point ;
    }

    public float GetSpeedPoint()
    {
        return speed_point;
    }

    public float GetMagicPoint()
    {                                     
        return magic_point;
    }

    public float GetLuckPoint()
    {
        return luck_point;
    }

    public float GetDefencePoint()
    {
        return defence_point;
    }

    //incrementer
    public void AddHealthPoint(float value)
    {
        health_point += value;
    }

    public void AddEnergyPoint(float value)
    {
        energy_point += value;
    }

    public void AddAttackPoint(float value)
    {
        attack_point += value;
    }

    public void AddSpeedPoint(float value)
    {
        speed_point += value;
    }

    public void AddMagicPoint(float value)
    {
        magic_point += value;
    }

    public void AddLuckPoint(float value)
    {
        luck_point += value;
    }

    public void AddDefencePoint(float value)
    {
        defence_point += value;
    }

    //decrementer
    public void MinusHealthPoint(float value)
    {
        health_point -= value;
    }

    public void TakeDamage(float value)
    {
        health_point -= value;
    }

    public void MinusEnergyPoint(float value)
    {
        energy_point -= value;
    }

    public void MinusAttackPoint(float value)
    {
        attack_point -= value;
    }

    public void MinusSpeedPoint(float value)
    {
        speed_point -= value;
    }

    public void MinusMagicPoint(float value)
    {
        magic_point -= value;
    }

    public void MinusLuckPoint(float value)
    {
        luck_point -= value;
    }

    public void MinusDefencePoint(float value)
    {
        defence_point -= value;
    }
}
