using UnityEngine;

public class CorrectStatement : MonoBehaviour, Statement
{
	bool Statement.IsStatementTrue()
	{
		return true;
	}
}

