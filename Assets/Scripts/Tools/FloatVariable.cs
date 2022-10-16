using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Variable", menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject
{
    public float Value;

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}