using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

public class BehaviorTreeView : GraphView
{
    public new class UxmlFactory : UxmlFactory<BehaviorTreeView, GraphView.UxmlTraits> { }
    public BehaviorTreeView() 
    {
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Programmers/AI/BehaviourTree/Editor/BehaviourTreeEditor.uss");

        styleSheets.Add(styleSheet);
    }
}
