using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public Material litMaterial;
    public Shader variableLitShader;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }
            return instance;
        }
    }

    private void Awake()
    {
        SetupMaterials();
    }

    private void SetupMaterials()
    {
        // Create Sprite-Lit material if not assigned
        if (litMaterial == null)
        {
            Shader litShader = Shader.Find("Universal Render Pipeline/2D/Sprite-Lit-Default");
            if (litShader != null)
                litMaterial = new Material(litShader);
            else
                Debug.LogError("Sprite-Lit shader not found!");
        }

        // Create Sprite-Unlit material if not assigned
        if (variableLitShader == null)
        {
            variableLitShader = Shader.Find("Shader Graphs/Dungeon Light Shader_Variable");
        }
        else 
        { 
            Debug.LogError("Sprite-Unlit shader not found!");
        }
    }

    #region Header Dungeon  
    [Space(10)]
    [Header("Dungeon")]
    #endregion
    #region Tooltip
    [Tooltip("Populate with RoomNodeTypeListSO")]
    #endregion

    public RoomNodeTypeListSO roomNodeTypeList;

    public CurrentPlayerSO currentPlayer;

    #region Header MATERIALS
    [Space(10)]
    [Header("MATERIALS")]
    #endregion

    #region Tooltip
    [Tooltip("Dimmed Material")]
    #endregion
    public Material dimmedMaterial;
    //public Material litMaterial = Materia;
    //public Shader variableLitShader = Shader.Find("Shader Graphs/Dungeon Light Shader_Variable");

//    #region Validation
//#if UNITY_EDITOR
    // Validate the scriptable object details entered
//    private void OnValidate()
//    {
//        HelperUtilities.ValidateCheckNullValue(this, nameof(roomNodeTypeList), roomNodeTypeList);
//        HelperUtilities.ValidateCheckNullValue(this, nameof(currentPlayer), currentPlayer);
//        HelperUtilities.ValidateCheckNullValue(this, nameof(litMaterial), litMaterial);
//        HelperUtilities.ValidateCheckNullValue(this, nameof(dimmedMaterial), dimmedMaterial);
//        HelperUtilities.ValidateCheckNullValue(this, nameof(variableLitShader), variableLitShader);
//    }
//#endif
//    #endregion
}
