using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(VariablesResetter))]
public class CustomInspectorForVariableResetter : Editor
{
    public IntVariable RowsS;
    public IntVariable ColumnsS;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        VariablesResetter resseter = (VariablesResetter)target;
        if (GUILayout.Button("Reset Variables To Default Values"))
        {
            resseter.ResetVaraiblesToDefaultValues();
        }
    }
}
#endif