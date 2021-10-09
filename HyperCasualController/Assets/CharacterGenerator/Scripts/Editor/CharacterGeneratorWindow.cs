using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterGeneratorWindow : EditorWindow
{
    Texture icon;

    Object playerModel;
    bool canAnim;
    bool wantCamera;
    [MenuItem("Window/CharacterGenerator")]
    public static void ShowWindow()
    {
        GetWindow<CharacterGeneratorWindow>("Generate Character");
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(Screen.width / 8);
        Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/CharacterGenerator/Scripts/Editor/Icon/bannerunity.png", typeof(Texture));
        GUILayout.Box(banner);
        GUILayout.EndHorizontal();
        

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Your model:");
        playerModel = EditorGUILayout.ObjectField(playerModel,typeof(Object),true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Can your model be animated?");
        canAnim = EditorGUILayout.Toggle(canAnim);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.HelpBox("Make sure your model is humanoid", MessageType.Info);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Do you want a chasing camera?");
        wantCamera = EditorGUILayout.Toggle(wantCamera);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.HelpBox("If you want a chasing camera please remove your camera from scene", MessageType.Info);

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Generate Character"))
        {
            CharacterGenerator.GenerateCharacter(playerModel, canAnim, wantCamera);
        }
        EditorGUILayout.EndHorizontal();
    }
}
