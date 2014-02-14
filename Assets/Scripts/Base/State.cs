using System;
using UnityEngine;
using System.Collections;

public abstract class State <T>
{
	public abstract void EnterState();
	public abstract void UpdateState();
	public abstract void UpdateStateGUI();
	public abstract void ExitState();
}
