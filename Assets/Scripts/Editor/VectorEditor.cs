using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Conditions.Vector3))]
public class VectorEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var xProp = property.FindPropertyRelative("x");
        var yProp = property.FindPropertyRelative("y");
        var zProp = property.FindPropertyRelative("z");

        position.height = 20f;

        label.text = "X";
        EditorGUI.PropertyField(position, xProp, label);

        label.text = "Y";
        position.y += 20f;
        EditorGUI.PropertyField(position, yProp, label);

        label.text = "Z";
        position.y += 20f;
        EditorGUI.PropertyField(position, zProp, label);

        EditorGUI.EndProperty();
    }
}
