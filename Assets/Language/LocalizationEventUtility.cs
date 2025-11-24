#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Localization.Components;
using TMPro;

public static class LocalizationEventUtility
{
    public static void AddPersistentTextListener(LocalizeStringEvent targetEvent, TextMeshProUGUI text)
    {
#if UNITY_EDITOR
        SerializedObject so = new SerializedObject(targetEvent);
        SerializedProperty prop = so.FindProperty("m_UpdateString.m_PersistentCalls.m_Calls");

        // Tạo một listener mới
        int index = prop.arraySize;
        prop.InsertArrayElementAtIndex(index);

        SerializedProperty element = prop.GetArrayElementAtIndex(index);

        // Set target object
        element.FindPropertyRelative("m_Target").objectReferenceValue = text;

        // Gọi vào TextMeshProUGUI.text
        element.FindPropertyRelative("m_MethodName").stringValue = "set_text";

        // Mode: String parameter
        element.FindPropertyRelative("m_Mode").intValue = 5;   // PersistentListenerMode.String

        // Call State: Editor and Runtime
        element.FindPropertyRelative("m_CallState").intValue = 2; // UnityEventCallState.EditorAndRuntime

        // Parameter: string
        var arg = element.FindPropertyRelative("m_Arguments").FindPropertyRelative("m_StringArgument");
        arg.stringValue = "";

        so.ApplyModifiedProperties();
#endif
    }
}
