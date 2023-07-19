using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]

public class BehaviourTree : ScriptableObject
{/// <summary>
/// a root node forthe tree
/// </summary>
    public Node rootNode;
    /// <summary>
    /// the state the node is a the curretn state in time
    /// </summary>
    public Node.State treeState = Node.State.Running;

    public List<Node> nodes = new List<Node>();
    public Blackboard blackboard = new Blackboard();
    public static Node currentNode;
    /// <summary>
    /// check what state the node is in athe current point an tiem and return the state
    /// </summary>
    /// <returns> returns the state the node is in</returns>
    public Node.State Update() 
    {
        if (rootNode.state == Node.State.Running)
        {
            
            return rootNode.Update();
            
        }
        
        return treeState;
    }
#if UNITY_EDITOR
    public Node CreateNode(System.Type type) 
    {
        Node node = ScriptableObject.CreateInstance(type) as Node;
        node.name = type.Name;

        node.guid = GUID.Generate().ToString();

        Undo.RecordObject(this, "Behavior Tree (CreateNode)");
        nodes.Add(node);
        if (!Application.isPlaying)
        {
            AssetDatabase.AddObjectToAsset(node, this);
        }
        Undo.RegisterCompleteObjectUndo(node, "Behavior Tree (CreateNode)");

        AssetDatabase.SaveAssets();
        return node;
    }

    public void DeleteNode(Node node) 
    {

        Undo.RecordObject(this, "Behavior Tree (DeleteNode)");
        nodes.Remove(node);
        //AssetDatabase.RemoveObjectFromAsset(node);
        Undo.DestroyObjectImmediate(node);
        AssetDatabase.SaveAssets();
    }

    public void AddChild(Node parent, Node child) 
    {
        DecoratorNode decorator = parent as DecoratorNode;
        if (decorator) 
        {
            Undo.RecordObject(decorator, "Behaviour Tree (AddChild)");

            decorator.child = child;
            EditorUtility.SetDirty(decorator);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            Undo.RecordObject(rootNode, "Behaviour Tree (AddChild)");
            rootNode.child = child;
            EditorUtility.SetDirty(rootNode);
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            Undo.RecordObject(composite, "Behaviour Tree (AddChild)");
            composite.children.Add(child);
            EditorUtility.SetDirty(composite);
        }
    }
    public void RemoveChild(Node parent, Node child)
    {
        DecoratorNode decorator = parent as DecoratorNode;
        if (decorator)
        {
            Undo.RecordObject(decorator, "Behaviour Tree (RemoveChild)");
            decorator.child = null;
            EditorUtility.SetDirty(decorator);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            Undo.RecordObject(rootNode, "Behaviour Tree (RemoveChild)");
            rootNode.child = null;
            EditorUtility.SetDirty(rootNode);
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            Undo.RecordObject(composite, "Behaviour Tree (RemoveChild)");
            composite.children.Remove(child);
            EditorUtility.SetDirty(composite);
        }
    }
#endif
    //end of editor only
    public static List<Node> GetChildren(Node parent )
    {
        List<Node> children = new List<Node>();

        DecoratorNode decorator = parent as DecoratorNode;
        if (decorator && decorator.child != null)
        {
            children.Add(decorator.child);
        }
        RootNode rootNode = parent as RootNode;
        if (rootNode && rootNode.child != null)
        {
            children.Add(rootNode.child);
        }
        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            return composite.children;
        }
        return children;
    }

    public static void Traverse(Node node, System.Action<Node> visiter) 
    {
        if (node) 
        {
            currentNode = node;
            visiter.Invoke(node);
            var children = GetChildren(node);
            children.ForEach((n) => Traverse(n, visiter));
        }
    }
    
    public BehaviourTree Clone() 
    {
        BehaviourTree tree = Instantiate(this);
        tree.rootNode = tree.rootNode.Clone();
        tree.nodes = new List<Node>();
        Traverse(tree.rootNode, (n) => {
            tree.nodes.Add(n);
        });
        return tree;
    }

    public void Bind(AnimalAgent agent) 
    {
        Traverse(rootNode, node => {
            node.agent = agent;
            node.blackboard = blackboard;
        });
    }
}
