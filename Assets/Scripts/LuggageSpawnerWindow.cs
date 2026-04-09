using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LuggageSpawnerWindow : EditorWindow
{
    [SerializeField] private float blockSize = 0.25f;
    [SerializeField] private GameObject prefabToUse;

    public enum LuggageShapes
    {
        OneByOne,
        OneByTwo,
        OneByThree,
        TwoByTwo,
        L,
        ZigZag,
    }
    [SerializeField] private LuggageShapes shape = LuggageShapes.OneByOne;
    [SerializeField] private float multiplier = 0.0f;
    [SerializeField] private float baseValue = 100f;

    public enum LuggageModifiers
    {
        Fragile,
        Spikes,
        Expandable
    }
    [SerializeField] private LuggageModifiers modifier = LuggageModifiers.Fragile;

    [MenuItem("Tools/ Luggage Generator")]
    public static void ShowWindow()
    {
        GetWindow<LuggageSpawnerWindow>("Luggage Generator");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Prefab to use", EditorStyles.boldLabel);

        blockSize = EditorGUILayout.FloatField("Block Size", blockSize);
        prefabToUse = (GameObject)EditorGUILayout.ObjectField("Prefab", prefabToUse, typeof(GameObject), false);
        shape = (LuggageShapes)EditorGUILayout.EnumPopup("Luggage Shape", shape);
        multiplier = EditorGUILayout.FloatField("Multiplier Value", multiplier);
        baseValue = EditorGUILayout.FloatField("Base Value", baseValue);
        modifier = (LuggageModifiers)EditorGUILayout.EnumPopup("Luggage Modifier", modifier);


        EditorGUILayout.Space();
        if (GUILayout.Button("Generate")) Generate();

    }

    private void Generate()
    {
        switch (shape){
            case LuggageShapes.OneByOne:
                SpawnOneByOneLuggage();
                break;
            case LuggageShapes.OneByTwo:
                SpawnOneByTwoLuggage();
                break;
            case LuggageShapes.OneByThree:
                SpawnOneByThreeLuggage();
                break;
            case LuggageShapes.TwoByTwo:
                SpawnTwoByTwoLuggage();
                break;
            case LuggageShapes.L:
                SpawnLShapedLuggage();
                break;
            case LuggageShapes.ZigZag:
                SpawnZigZagShapedLuggage();
                break;
        }
        Debug.Log(shape);
    }

    private void SpawnOneByOneLuggage()
    {

        List<GameObject> blocks = GenerateBlocks(1);
        blocks[0].transform.localPosition = Vector3.zero;
        AddShapesToParent(blocks);
    }

    private void SpawnOneByTwoLuggage()
    {

        List<GameObject> blocks = GenerateBlocks(2);

        blocks[0].transform.localPosition = Vector3.zero;
        blocks[1].transform.localPosition = Vector3.zero + (new Vector3(0,0,1) * blockSize);
        AddShapesToParent(blocks);

    }
    private void SpawnOneByThreeLuggage()
    {
        List<GameObject> blocks = GenerateBlocks(3);

        blocks[0].transform.localPosition = Vector3.zero;
        blocks[1].transform.localPosition = Vector3.zero + (new Vector3(0, 0, 1) * blockSize);
        blocks[2].transform.localPosition = Vector3.zero + (new Vector3(0,0,-1) * blockSize);

        AddShapesToParent(blocks);
    }
    private void SpawnTwoByTwoLuggage()
    {
        List<GameObject> blocks = GenerateBlocks(4);

        blocks[0].transform.localPosition = Vector3.zero;
        blocks[1].transform.localPosition = Vector3.zero + (new Vector3(0, 0, 1) * blockSize);
        blocks[2].transform.localPosition = Vector3.zero + (new Vector3(1, 0, 0) * blockSize);
        blocks[3].transform.localPosition = Vector3.zero + (new Vector3(1, 0, 1) * blockSize);

        AddShapesToParent(blocks);
    }
    private void SpawnLShapedLuggage()
    {
        List<GameObject> blocks = GenerateBlocks(4);

        blocks[0].transform.localPosition = Vector3.zero;
        blocks[1].transform.localPosition = Vector3.zero + (new Vector3(0, 0, 1) * blockSize);
        blocks[2].transform.localPosition = Vector3.zero + (new Vector3(0, 0, -1) * blockSize);
        blocks[3].transform.localPosition = Vector3.zero + (new Vector3(1, 0, 1) * blockSize);

        AddShapesToParent(blocks);
    }
    private void SpawnZigZagShapedLuggage()
    {
        List<GameObject> blocks = GenerateBlocks(4);

        blocks[0].transform.localPosition = Vector3.zero;
        blocks[1].transform.localPosition = Vector3.zero + (new Vector3(0, 0, 1) * blockSize);
        blocks[2].transform.localPosition = Vector3.zero + (new Vector3(-1, 0, 0) * blockSize);
        blocks[3].transform.localPosition = Vector3.zero + (new Vector3(1, 0, 1) * blockSize);

        AddShapesToParent(blocks);
    }

    private void AddShapesToParent(List<GameObject> blocks)
    {
        GameObject parentObject = new GameObject(shape.ToString());
        foreach (GameObject item in blocks)
        {
           item.transform.SetParent(parentObject.transform);
        }
        parentObject.AddComponent<LuggagePiece>().InitProperties(shape.ToString(), baseValue, multiplier, modifier.ToString());

    }

    private List<GameObject> GenerateBlocks(int size)
    {
        List<GameObject> blocks = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject block = (GameObject)PrefabUtility.InstantiatePrefab(prefabToUse);
            block.transform.localScale = Vector3.one * blockSize;
            blocks.Add(block);
        }
        return blocks;
    }
}
