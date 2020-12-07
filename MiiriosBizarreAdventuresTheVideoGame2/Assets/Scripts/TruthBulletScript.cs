using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruthBulletScript : MonoBehaviour
{
	public Text BulletText;
	public int BulletNumb = 0;
	public bool Active = false;
	private RectTransform RT;
	private ClassDebateManager CBM;

	public void Start()
	{
		RT = GetComponent<RectTransform>();
		CBM = ClassDebateManager.instance;
	}

	public void SetText(string inc)
	{
		BulletText.text = inc;
	}

	public void SetAsActive()
	{
		if (!Active)
		{
			CBM.SetBulletAsActive(BulletNumb);
			RT.localPosition += Vector3.right * 150;
			Active = true;

		} //otherwise it's already active
	}

	public void SetAsNotActive()
	{
		if (Active)
		{
			RT.localPosition += Vector3.left * 150;
			Active = false;
		}
	}
}
