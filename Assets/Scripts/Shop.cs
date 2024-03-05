using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased!");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Another Turret Purchased!");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}
