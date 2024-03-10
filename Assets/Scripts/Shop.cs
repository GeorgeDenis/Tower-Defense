using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased!");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("MissileLauncher Selected!");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
