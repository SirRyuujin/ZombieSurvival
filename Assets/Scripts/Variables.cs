using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : ScriptableObject
{
    public dynamic Value;

    public virtual dynamic GetValue() { return Value; }

    public virtual void SetValue(dynamic value) { Value = value; }
}