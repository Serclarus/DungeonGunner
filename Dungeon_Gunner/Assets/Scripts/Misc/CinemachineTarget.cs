using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineTargetGroup))]
public class CinemachineTarget : MonoBehaviour
{
    private CinemachineTargetGroup cinemachineTargetGroup;

    [SerializeField] Transform cursorTarget;

    private void Awake()
    {
        // Load components
        cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();
    }

    void Start()
    {
        SetCinemachineTargetGroup();
    }
    private void Update()
    {
        cursorTarget.position = HelperUtilities.GetMouseWorldPosition();
    }

    /// <summary>
    /// Set the cinemachine camera target group.
    /// </summary>
    private void SetCinemachineTargetGroup()
    {
        // Create target group for cinemachine for the cinemachine camera to follow
        CinemachineTargetGroup.Target cinemachineGroupTarget_player = new CinemachineTargetGroup.Target
        {
            weight = 1f,
            radius = 2.5f,
            target = GameManager.Instance.GetPlayer().transform
        };

        CinemachineTargetGroup.Target cinemachineGroupTarget_cursor = new CinemachineTargetGroup.Target
        {
            weight = 1f,
            radius = 1f,
            target = cursorTarget
        };

        CinemachineTargetGroup.Target[] cinemachineTargetArray = new CinemachineTargetGroup.Target[]
        {
            cinemachineGroupTarget_player, cinemachineGroupTarget_cursor
        };

        cinemachineTargetGroup.m_Targets = cinemachineTargetArray;
    }
}