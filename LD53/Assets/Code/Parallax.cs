using UnityEngine;

//Version 1.0 - 19 April 2020
//Created by This Isn't Games.
//Free to use in commercial projects.

[HelpURL("https://thisisntgames.itch.io/parallax")]
public class Parallax : MonoBehaviour
{
    [Tooltip("Drag Camera Object")]
    [SerializeField]
    private Transform stageCamera = null;
    private Vector2 cameraStartPosition;
    private Vector2 cameraCurrentPosition => stageCamera.position;
    private Vector2 deltaCamera;

    //[Tooltip("Restriction of the Y-Axis Movement")]
    //[SerializeField][Range(0f, 1f)] private float verticalRestriction = 0.5f;

    [System.Serializable]
    public class ParallaxLayer
    {
        public string Name;
        [Tooltip("Put all objects for one layer under a parent object.")]
        public Transform layerObject;
        [Tooltip("Positive is Furthest Away.")]
        [Range(-1, 1)] public float distanceFromCamera;
    }

    [Tooltip("How many layers will this Parallax have? ")]
    public ParallaxLayer[] layer;

    void Start()
    {
        cameraStartPosition = stageCamera.position;
    }

    void Update()
    {
        deltaCamera = cameraCurrentPosition - cameraStartPosition;

        for (int i = 0, n = layer.Length; i < n; i++)
        {
            var currentLayer = layer[i];
            var layerPosit = currentLayer.layerObject.position;
            var multiplyerX = currentLayer.distanceFromCamera;
            //var multiplyerY = ((1 - multiplyerX) * verticalRestriction) + multiplyerX;
			

            layerPosit.x = deltaCamera.x * multiplyerX;
            //layerPosit.y = deltaCamera.y * multiplyerY;

            currentLayer.layerObject.position = layerPosit;
        }
    }
}