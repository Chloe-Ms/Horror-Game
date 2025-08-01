using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Managers
{
    public static TidyingManager TidyingObjectsManager { get; set; } = null;

    public static ProductsInventory ProductsInventory { get; set; } = null;

    public static bool ShouldDisplayInteractable = true;
}
