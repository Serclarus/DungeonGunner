using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomNodeGraph", menuName = "ScriptableObjects/Dungeon/RoomNodeType")]

public class RoomNodeTypeSO : ScriptableObject
{
    public string roomNodeTypeName;
    public bool displayInTheGraphEditor;
    public bool isCorridor;
    public bool isCorridorNS;
    public bool isCorridorEW;
    public bool isEntrance;
    public bool isBossRoom;
    public bool isNone;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(roomNodeTypeName),roomNodeTypeName);
    }
#endif
    #endregion
}
