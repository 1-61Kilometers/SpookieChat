
using UnityEngine;
using VRC.SDK3.Components;

namespace UdonSharp.Examples.Utilities
{
    /// <summary>
    /// A Basic example class that demonstrates how to toggle a list of object on and off when someone interacts with the UdonBehaviour
    /// This toggle only works locally
    /// </summary>
    [AddComponentMenu("Udon Sharp/Utilities/Interact Toggle")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    public class InteractToggle : UdonSharpBehaviour 
    {
        public PlaneResize plane;
        [Tooltip("List of objects to toggle on and off")]
        public GameObject toggleOffObjects;
        public GameObject toggleOnObjects;

        public override void Interact()
        {
            plane.StartMoving();
            toggleOffObjects.SetActive(false);
            toggleOnObjects.SetActive(true);
        }
    }
}
