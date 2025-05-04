using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public static BuildManager instance;


    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();

    }

    public void SelectNode(Node node)
    {

        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.currentTurret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);


        Debug.Log("Turret built, money left: " + PlayerStats.money);
    }

}
