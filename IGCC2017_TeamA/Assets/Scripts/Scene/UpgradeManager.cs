﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	private ItemHolder m_item = null;
	// Use this for initialization
	void Start () {
		m_item = ItemHolder.instance;
	}

	public bool UpgradeAttack(GameObject robot)
	{
		var stats = robot.GetComponent<Robot_Status>().base_attack_point;

		bool isUpgrade = m_item.UseItem((int)stats);
		if (isUpgrade)
		{
			robot.GetComponent<Robot_Status>().AddBaseAttackPoint(1.0f);
		}

		return isUpgrade;
	}

	public bool UpgradeDefence(GameObject robot)
	{
		var stats = robot.GetComponent<Robot_Status>().base_defence_point;

		bool isUpgrade = m_item.UseItem((int)stats);
		if (isUpgrade)
		{
			robot.GetComponent<Robot_Status>().AddBaseDefencePoint(1.0f);
		}

		return isUpgrade;
	}

	public bool UpgradeSpeed(GameObject robot)
	{
		var stats = robot.GetComponent<Robot_Status>().base_speed_point;

		bool isUpgrade = m_item.UseItem((int)stats);
		if (isUpgrade)
		{
			robot.GetComponent<Robot_Status>().AddBaseSpeedPoint(0.1f);
		}

		return isUpgrade;
	}

	public bool UpgradeMagic(GameObject robot)
	{
		var stats = robot.GetComponent<Robot_Status>().base_magic_point;

		bool isUpgrade = m_item.UseItem((int)stats);
		if (isUpgrade)
		{
			robot.GetComponent<Robot_Status>().AddBaseMagicPoint(1.0f);
		}

		return isUpgrade;
	}

	public bool UpgradeLuck(GameObject robot)
	{
		var stats = robot.GetComponent<Robot_Status>().base_luck_point;

		bool isUpgrade = m_item.UseItem((int)stats);
		if (isUpgrade)
		{
			robot.GetComponent<Robot_Status>().AddLuckPoint(1.0f);
		}

		return isUpgrade;
	}
	public bool UpgradeHP(GameObject robot)
	{
		var stats = robot.GetComponent<Robot_Status>().base_health_point;

		bool isUpgrade = m_item.UseItem((int)stats);
		if (isUpgrade)
		{
			robot.GetComponent<Robot_Status>().AddBaseHealthPoint(10.0f);
		}

		return isUpgrade;
	}

	public bool UpgradeEnergy(GameObject robot)
	{
		var stats = robot.GetComponent<Robot_Status>().base_energy_point;

		bool isUpgrade = m_item.UseItem((int)stats);
		if (isUpgrade)
		{
			robot.GetComponent<Robot_Status>().AddBaseEnergyPoint(10.0f);
		}

		return isUpgrade;
	}
}
