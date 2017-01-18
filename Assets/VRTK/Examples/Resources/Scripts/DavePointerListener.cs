namespace VRTK.Examples
{
    using UnityEngine;

    public class DavePointerListener : MonoBehaviour
    {

       
        private void Start()
        {
            if (GetComponent<VRTK_SimplePointer>() == null)
            {
                Debug.LogError("VRTK_ControllerPointerEvents_ListenerExample is required to be attached to a Controller that has the VRTK_SimplePointer script attached to it");
                return;
            }

            //Setup controller event listeners
            GetComponent<VRTK_SimplePointer>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
            GetComponent<VRTK_SimplePointer>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
            GetComponent<VRTK_SimplePointer>().DestinationMarkerSet += new DestinationMarkerEventHandler(DoPointerDestinationSet);
        }

        private void DebugLogger(uint index, string action, Transform target, RaycastHit raycastHit, float distance, Vector3 tipPosition)
        {
            string targetName = (target ? target.name : "<NO VALID TARGET>");
            string colliderName = (raycastHit.collider ? raycastHit.collider.name : "<NO VALID COLLIDER>");
            Debug.Log("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named [" + targetName + "] on the collider named [" + colliderName + "] - the pointer tip position is/was: " + tipPosition);
        }

        private void DoPointerIn(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(e.controllerIndex, "POINTER IN", e.target, e.raycastHit, e.distance, e.destinationPosition);
            

        }

        private void DoPointerOut(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(e.controllerIndex, "POINTER OUT", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs e)
        {
			
            //if (e.controllerIndex.Equals(GetComponent<DaveControllerListener>().leftControllerIndex)) {
			//if (VRTK_DeviceFinder.GetControllerByIndex(e.controllerIndex) == SDK_BaseController.ControllerHand.Left) {
			if (VRTK_DeviceFinder.GetControllerLeftHand(false) == VRTK_DeviceFinder.GetControllerByIndex(e.controllerIndex, false)) {
                // dave, toggle the rigidbody of the block
                //GetComponent<ReporterScript>().pointerTarget = e.target.gameObject;

                Rigidbody r = e.target.gameObject.GetComponent<Rigidbody>();
                if (r.isKinematic)
                {
                    r.isKinematic = false;
                }
                else
                {
                    r.isKinematic = true;
                }
            }
            else {  // let's assume it's right controller for now, dave
                // if it's a cube, destroy it
                if (e.target.gameObject.tag.Equals("BuildingBlock"))
                {
                    Destroy(e.target.gameObject);
                }
            }
            DebugLogger(e.controllerIndex, "POINTER DESTINATION", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }
    }
}