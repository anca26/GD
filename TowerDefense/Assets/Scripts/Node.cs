using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 offset;
    private Renderer rend;
    private Color startColor;

    private GameObject currentTurret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (currentTurret != null)
        {
            Debug.Log("Can't build here! - display later on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        currentTurret = (GameObject)Instantiate(turretToBuild, transform.position + offset, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
