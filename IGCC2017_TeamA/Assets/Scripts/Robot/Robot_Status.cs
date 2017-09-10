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

public enum ACTIONS
{
    ATTACK,
    GATHER,
    HEAL,
    RESCUE,
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

    public State_Manager state_manager;
    public Robot_Inventory inventory;

    float chance_attack;
    float chance_gather;
    float chance_heal;
    float chance_rescue;
    // Use this for initialization
    void Start () {
        state_manager = GetComponentInChildren<State_Manager>();
        inventory = GetComponentInChildren<Robot_Inventory>();
        chance_attack = 50f;
        chance_gather = 50f;
        chance_heal = 50f;
        chance_rescue = 50f;
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
        mood = (PERSONALITY)Random.Range(0, (int)PERSONALITY.TOTAL);
        MoodOnEffectingStats();
    }

    public void ResetAllStats()
    {
        attack_point = base_attack_point;
        speed_point = base_speed_point;
        magic_point = base_magic_point;
        luck_point = base_luck_point;
        defence_point = base_defence_point;
        health_point = base_health_point;
        energy_point = base_energy_point;

        mood = (PERSONALITY)Random.Range(0, (int)PERSONALITY.TOTAL);
        MoodOnEffectingStats();
    } 

    public void MoodOnEffectingStats()
    {
        switch (mood)
        {
            case PERSONALITY.BRAVE:
                attack_point = base_attack_point * 1.2f;
                defence_point = base_defence_point * 0.8f;

                chance_attack = 70f;
                chance_gather = 50f;
                chance_heal = 50f;
                chance_rescue = 50f;
                break;
            case PERSONALITY.CURIOUS:
                luck_point = base_luck_point * 1.2f;
                defence_point = base_defence_point * 0.8f;
                chance_attack = 50f;
                chance_gather = 70f;
                chance_heal = 50f;
                chance_rescue = 50f;
                break;
            case PERSONALITY.SENSITIVE:
                magic_point = base_magic_point * 1.2f;
                attack_point = base_attack_point * 0.8f;

                chance_attack = 50f;
                chance_gather = 50f;
                chance_heal = 70f;
                chance_rescue = 70f;
                break;
            case PERSONALITY.LAZY:
                attack_point = base_attack_point * 0.8f;
                speed_point = base_speed_point * 0.8f;
                magic_point = base_magic_point * 0.8f;
                luck_point = base_luck_point * 0.8f;
                defence_point = base_defence_point * 0.8f;

                chance_attack = 30f;
                chance_gather = 30f;
                chance_heal = 30f;
                chance_rescue = 30f;
                break;
            case PERSONALITY.IMPATIENT:
                speed_point = base_speed_point * 1.2f;
                luck_point = base_luck_point * 0.8f;

                chance_attack = 50f;
                chance_gather = 30f;
                chance_heal = 50f;
                chance_rescue = 50f;
                break;
            case PERSONALITY.CAREFUL:
                defence_point = base_defence_point * 1.2f;
                speed_point = base_speed_point * 0.8f;

                chance_attack = 50f;
                chance_gather = 50f;
                chance_heal = 50f;
                chance_rescue = 50f;
                break;
            default:
                break;
        }


        switch (personality)
        {
            case PERSONALITY.BRAVE:
                chance_attack += 20f;
                break;
            case PERSONALITY.CURIOUS:
                chance_gather += 20f;
                break;
            case PERSONALITY.SENSITIVE:
                chance_heal += 20f;
                chance_rescue += 20f;
                break;
            case PERSONALITY.LAZY:
                chance_attack -= 20f;
                chance_gather -= 20f;
                chance_heal -= 20f;
                chance_rescue -= 20f;
                break;
            case PERSONALITY.IMPATIENT:
                chance_gather -= 20f;
                break;
            case PERSONALITY.CAREFUL:
                break;
            default:
                break;
        }
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
    public State_Manager GetStateManager()
    {
        return state_manager;
    }

    public float GetHealthPoint()
    {
        return health_point;
    }

    public float GetEnergyPoint()
    {
        return energy_point;
    }

    public float GetAttackPoint()
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

    public float GetBaseAttackPoint()
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


    public float GetChanceToAttack()
    {
        return chance_attack;
    }

    public float GetChanceToGather()
    {
        return chance_gather;
    }

    public float GetChanceToHeal()
    {
        return chance_heal;
    }

    public float GetChanceToRescue()
    {
        return chance_rescue;
    }

    public PERSONALITY GetPersonality()
    {
        return personality;
    }

    //incrementer
    public void AddHealthPoint(float value)
    {
        health_point = Mathf.Clamp( health_point+value, 0f,base_health_point);
    }

    public void AddEnergyPoint(float value)
    {
        energy_point = Mathf.Clamp(energy_point + value, 0f, base_energy_point);
    }

    public void AddAttackPoint(float value)
    {
        attack_point += Mathf.Abs(value);
    }

    public void AddSpeedPoint(float value)
    {
        speed_point += Mathf.Abs(value);
    }

    public void AddMagicPoint(float value)
    {
        magic_point += Mathf.Abs(value);
    }

    public void AddLuckPoint(float value)
    {
        luck_point += Mathf.Abs(value);
    }

    public void AddDefencePoint(float value)
    {
        defence_point += Mathf.Abs(value);
    }

    public void AddBaseHealthPoint(float value)
    {
        base_health_point += Mathf.Abs(value);
    }

    public void AddBaseEnergyPoint(float value)
    {
        base_energy_point += Mathf.Abs(value);
    }

    public void AddBaseAttackPoint(float value)
    {
        base_attack_point += Mathf.Abs(value);
    }

    public void AddBaseSpeedPoint(float value)
    {
        base_speed_point += Mathf.Abs(value);
    }

    public void AddBaseMagicPoint(float value)
    {
        base_magic_point += Mathf.Abs(value);
    }

    public void AddBaseLuckPoint(float value)
    {
        base_luck_point += Mathf.Abs(value);
    }

    public void AddBaseDefencePoint(float value)
    {
        base_defence_point += Mathf.Abs(value);
    }

    //decrementer
    public void MinusHealthPoint(float value)
    {
        health_point -= Mathf.Abs(value);
        if (health_point < 0f)
        {
            health_point = 0;
        }
    }

    public void TakeDamage(float value)
    {
        health_point -= Mathf.Clamp( value - (defence_point* 1.2f),0,health_point);
    }

    public void MinusEnergyPoint(float value)
    {
        energy_point -= Mathf.Abs(value);
        if (energy_point < 0f)
        {
            energy_point = 0;
        }
    }

    public void MinusAttackPoint(float value)
    {
        attack_point -= Mathf.Abs(value);
        if (attack_point< 0f)
        {
            attack_point= 0;
        }
    }

    public void MinusSpeedPoint(float value)
    {
        speed_point -= Mathf.Abs(value);
        if (speed_point < 0f)
        {
            speed_point = 0;
        }
    }

    public void MinusMagicPoint(float value)
    {
        magic_point -= Mathf.Abs(value);
        if (magic_point < 0f)
        {
            magic_point = 0;
        }
    }

    public void MinusLuckPoint(float value)
    {
        luck_point -= Mathf.Abs(value);
        if (luck_point < 0f)
        {
            luck_point = 0;
        }
    }

    public void MinusDefencePoint(float value)
    {
        defence_point -= Mathf.Abs(value);
        if (defence_point< 0f)
        {
            defence_point = 0;
        }
    }

    public void MinusBaseHealthPoint(float value)
    {
        base_health_point -= Mathf.Abs(value);
        if (base_luck_point < 0f)
        {
            base_luck_point = 0;
        }
    }

    public void MinusBaseEnergyPoint(float value)
    {
        base_energy_point -= Mathf.Abs(value);
        if (base_luck_point < 0f)
        {
            base_luck_point = 0;
        }
    }

    public void MinusBaseAttackPoint(float value)
    {
        base_attack_point -= Mathf.Abs(value);
        if (base_luck_point < 0f)
        {
            base_luck_point = 0;
        }
    }

    public void MinusBaseSpeedPoint(float value)
    {
        base_speed_point -= Mathf.Abs(value);
        if (base_luck_point < 0f)
        {
            base_luck_point = 0;
        }
    }

    public void MinusBaseMagicPoint(float value)
    {
        base_magic_point -= Mathf.Abs(value);
        if (base_luck_point < 0f)
        {
            base_luck_point = 0;
        }
    }

    public void MinusBaseLuckPoint(float value)
    {
        base_luck_point -= Mathf.Abs(value);
        if (base_luck_point < 0f)
        {
            base_luck_point = 0;
        }
    }

    public void MinusBaseDefencePoint(float value)
    {
        base_defence_point -= Mathf.Abs(value);
        if(base_defence_point < 0f)
        {
            base_defence_point = 0;
        }
    }
}
