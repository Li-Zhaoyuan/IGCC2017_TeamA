using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	[SerializeField]
	private ClickObject m_clickObject;

	[SerializeField]
	private AudioSource m_upgradeSE;

	[SerializeField]
	private AudioSource m_upgradeFailedSE;

	private GameObject m_target = null;

	private ItemHolder m_item = null;

	private ITEM_TYPE m_type = ITEM_TYPE.RESOURCE_COG;

	// Use this for initialization
	void Start () {
		m_item = ItemHolder.instance;
	}
	void Update()
	{
		m_target = m_clickObject.m_target;
	}

	public void UpgradeAttack()
	{
		var stats = m_target.GetComponent<Robot_Status>().base_attack_point;

		bool isUpgrade = m_item.UseItem(m_type, (int)stats);
		isUpgrade = m_item.UseItem(m_type, 0);
		if (isUpgrade)
		{
			m_target.GetComponent<Robot_Status>().AddBaseAttackPoint(1.0f);
			m_upgradeSE.Play();
			return;
		}
		else
		{
			m_upgradeFailedSE.Play();
		}
	}

	public void UpgradeDefence()
	{
		var stats = m_target.GetComponent<Robot_Status>().base_defence_point;

		bool isUpgrade = m_item.UseItem(m_type,(int)stats);
		if (isUpgrade)
		{
			m_target.GetComponent<Robot_Status>().AddBaseDefencePoint(1.0f);
			m_upgradeSE.Play();
			return;
		}
		else
		{
			m_upgradeFailedSE.Play();
		}

	}

	public void UpgradeSpeed()
	{
		var stats = m_target.GetComponent<Robot_Status>().base_speed_point;

		bool isUpgrade = m_item.UseItem(m_type,(int)stats);
		if (isUpgrade)
		{
			m_target.GetComponent<Robot_Status>().AddBaseSpeedPoint(0.1f);
			m_upgradeSE.Play();
			return;
		}
		else
		{
			m_upgradeFailedSE.Play();
		}

	}

	public void UpgradeMagic()
	{
		var stats = m_target.GetComponent<Robot_Status>().base_magic_point;

		bool isUpgrade = m_item.UseItem(m_type, (int)stats);
		if (isUpgrade)
		{
			m_target.GetComponent<Robot_Status>().AddBaseMagicPoint(1.0f);
			m_upgradeSE.Play();
			return;
		}
		else
		{
			m_upgradeFailedSE.Play();
		}

	}

	public void UpgradeLuck()
	{
		var stats = m_target.GetComponent<Robot_Status>().base_luck_point;

		bool isUpgrade = m_item.UseItem(m_type,(int)stats);
		if (isUpgrade)
		{
			m_target.GetComponent<Robot_Status>().AddLuckPoint(1.0f);
			m_upgradeSE.Play();
			return;
		}
		else
		{
			m_upgradeFailedSE.Play();
		}

	}

	public void UpgradeHP()
	{
		var stats = m_target.GetComponent<Robot_Status>().base_health_point;

		bool isUpgrade = m_item.UseItem(m_type,(int)(stats/10.0f));
		if (isUpgrade)
		{
			m_target.GetComponent<Robot_Status>().AddBaseHealthPoint(10.0f);
			m_upgradeSE.Play();
			return;
		}
		else
		{
			m_upgradeFailedSE.Play();
		}

	}

	public void UpgradeEnergy()
	{
		var stats = m_target.GetComponent<Robot_Status>().base_energy_point;

		bool isUpgrade = m_item.UseItem(m_type,(int)(stats / 10.0f));
		if (isUpgrade)
		{
			m_target.GetComponent<Robot_Status>().AddBaseEnergyPoint(10.0f);
			m_upgradeSE.Play();
			return;
		}
		else
		{
			m_upgradeFailedSE.Play();
		}

	}
}
