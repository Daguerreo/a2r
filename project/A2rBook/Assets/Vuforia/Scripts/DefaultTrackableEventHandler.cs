/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNITY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
			//monster1AnimsNormal = transform.FindChild("monster1AnimsNormal").gameObject;
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNITY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
				Debug.LogError("Status :: " + newStatus);
				OnTrackingFound();
            }
            else
            {
				Debug.LogError("Status :: " + newStatus);
				OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			Animator[] animatorComponents = GetComponentsInChildren<Animator>(true);
			foreach (Animator component in animatorComponents)
			{
				component.SetBool ("InizioPar",true);
				component.SetBool ("Reset",false);
			}

			//Animator anim = GetComponentInChildren<Animator>();
			//anim.SetBool ("InizioPar",true);
			//anim.SetBool ("InizioPar2",true);

//			// *** Additional animation code
//			Animation[] animationComponents = GetComponentsInChildren<Animation>();
//			
//			foreach (Animation component in animationComponents)
//			{
//				component.Play();
//			}
//			// *** end of animation code
            
			// Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }



            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			//Animator anim = GetComponentInChildren<Animator>();
			Animator[] animatorComponents = GetComponentsInChildren<Animator>(true);
			foreach (Animator component in animatorComponents)
			{
				component.SetBool ("InizioPar",false);
				component.SetBool ("Reset",true);
		
			}

			//Animator anim = GetComponentInChildren<Animator>();
			//anim.SetBool ("InizioPar",false);
			//anim.SetBool ("InizioPar2", false);
			//anim.SetBool ("Reset",true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
