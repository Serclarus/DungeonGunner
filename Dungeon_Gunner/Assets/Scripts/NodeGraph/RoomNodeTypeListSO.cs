using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomNodeTypeListSO", menuName = "ScriptableObjects/Dungeon/Room Node Type List")]
public class RoomNodeTypeListSO : ScriptableObject
{
    public List<RoomNodeTypeSO> list;
    
    #region Validate
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(list), list);
    }
#endif
    #endregion
}
