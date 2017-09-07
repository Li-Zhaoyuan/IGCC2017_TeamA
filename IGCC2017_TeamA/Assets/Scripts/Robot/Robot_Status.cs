using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PERSONALITY
{
    BRAVE,
    CURIOUS,
    SENSITIVE,
    LAZY,
    IMPATIENT,
    CAREFUL,
    TOTAL
}

public class Robot_Status : MonoBehaviour {

    // all the status is now PUBLIC for debugging
    [Range(0,100)]
    public float health_point;
    [Range(0, 100)]
    public float energy_point;

    //base stats
    [Range(0, 100)]
    public float base_health_point;
    [Range(0, 100)]
    public float base_energy_point;

    public float base_attack_point;
    public float base_speed_point;
    public float base_magic_point;
    public float base_luck_point;
    public float base_defence_point;

    public float attack_point;
    public float speed_point;
    public float magic_point;
    public float luck_point;
    public float defence_point;



    public PERSONALITY personality;
    public PERSONALITY mood;
    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		//TODO: mood to affect stats
	}

    //Setters
    public void SetAllRobotStatus(float att,float spd,float mag, float luk, float def , float hp,float enrg,PERSONALITY p)
    {
        attack_point = att;
        speed_point = spd;
        magic_point = mag;
        luck_point = luk;
        defence_point = def;
        health_point = hp;
        energy_point = enrg;

        base_attack_point = att;
        base_speed_point = spd;
        base_magic_point = mag;
        base_luck_point = luk;
        base_defence_point = def;
        base_health_point = hp;
        base_energy_point = enrg;
        personality = p;
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

    public void SetBaseHealthPoint(float value)
    {
        base_health_point = value;
    }

    public void SetBaseEnergyPoint(float value)
    {
        base_energy_point = value;
    }

    public void SetBaseAttackPoint(float value)
    {
        base_attack_point = value;
    }

    public void SetBaseSpeedPoint(float value)
    {
        base_speed_point = value;
    }

    public void SetBaseMagicPoint(float value)
    {
        base_magic_point = value;
    }

    public void SetBaseLuckPoint(float value)
    {
        base_luck_point = value;
    }

    public void SetBaseDefencePoint(float value)
    {
        base_defence_point = value;
    }

    public void SetPersonality(PERSONALITY p)
    {
        personality = p;
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

    public float GetBaseHealthPoint()
    {
        return base_health_point;
    }

    public float GetBaseEnergyPoint()
    {
        return base_energy_point;
    }

    public float SetBaseAttackPoint()
    {
        return base_attack_point;
    }

    public float GetBaseSpeedPoint()
    {
        return base_speed_point;
    }

    public float GetBaseMagicPoint()
    {
        return base_magic_point;
    }

    public float GetBaseLuckPoint()
    {
        return base_luck_point;
    }

    public float GetBaseDefencePoint()
    {
        return base_defence_point;
    }

    public PERSONALITY GetPersonality()
    {
        return personality;
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

    public void AddBaseHealthPoint(float value)
    {
        base_health_point += value;
    }

    public void AddBaseEnergyPoint(float value)
    {
        base_energy_point += value;
    }

    public void AddBaseAttackPoint(float value)
    {
        base_attack_point += value;
    }

    public void AddBaseSpeedPoint(float value)
    {
        base_speed_point += value;
    }

    public void AddBaseMagicPoint(float value)
    {
        base_magic_point += value;
    }

    public void AddBaseLuckPoint(float value)
    {
        base_luck_point += value;
    }

    public void AddBaseDefencePoint(float value)
    {
        base_defence_point += value;
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

    public void MinusBaseHealthPoint(float value)
    {
        base_health_point -= value;
    }

    public void MinusBaseEnergyPoint(float value)
    {
        base_energy_point -= value;
    }

    public void MinusBaseAttackPoint(float value)
    {
        base_attack_point -= value;
    }

    public void MinusBaseSpeedPoint(float value)
    {
        base_speed_point -= value;
    }

    public void MinusBaseMagicPoint(float value)
    {
        base_magic_point -= value;
    }

    public void MinusBaseLuckPoint(float value)
    {
        base_luck_point -= value;
    }

    public void MinusBaseDefencePoint(float value)
    {
        base_defence_point -= value;
    }
}
