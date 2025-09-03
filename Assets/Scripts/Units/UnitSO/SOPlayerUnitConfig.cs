using System;
using System.Collections.Generic;
using UnityEngine;
using Units.Config;

[CreateAssetMenu(menuName = "Data/UnitSO/Player Unit Config")]
public class SOPlayerUnitConfig : SOUnitConfig
{
    private void OnEnable()
    {
        TeamType = TeamType.Player;
    }
}
