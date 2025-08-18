using UnityEngine;

[CreateAssetMenu(fileName = "MovementDetails_", menuName = "Scriptable Objects/Movement/MovementDetails")]
public class MovementDetailsSO : ScriptableObject
{
    [Header("MOVEMENT DETAILS")]
    [Tooltip("Minimum move speed.")]
    public float minMoveSpeed = 8f;
    [Tooltip("Maximum move speed.")]
    public float maxMoveSpeed = 8f;

    /// <summary>
    /// Get a random movement speed between the minimum and maximum values
    /// </summary>
    public float GetMoveSpeed()
    {
        if (minMoveSpeed == maxMoveSpeed)
        {
            return minMoveSpeed;
        }
        else
        {
            return Random.Range(minMoveSpeed, maxMoveSpeed);
        }
    }

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckPositiveRange(this, nameof(minMoveSpeed), minMoveSpeed, nameof(maxMoveSpeed), maxMoveSpeed, false);
    }
#endif
    #endregion Validation
}