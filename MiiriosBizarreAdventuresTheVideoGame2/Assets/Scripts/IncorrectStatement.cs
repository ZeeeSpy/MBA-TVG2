using UnityEngine;

public class IncorrectStatement : MonoBehaviour, Statement
{
	bool Statement.IsStatementTrue()
	{
		return false;
	}
}
