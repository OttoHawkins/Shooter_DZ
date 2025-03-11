using UnityEngine;
using System;

public class ChangeCubeColors : MonoBehaviour
{
    public GameObject[] cubes;
    public static event Action OnColorChange;

    void Start()
    {
        OnColorChange += ChangeColors;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnColorChange?.Invoke();
        }
    }

    private void ChangeColors()
    {
        foreach (GameObject cube in cubes)
        {
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                cubeRenderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
            }
        }
    }

    void OnDestroy()
    {
        OnColorChange -= ChangeColors;
    }
}
