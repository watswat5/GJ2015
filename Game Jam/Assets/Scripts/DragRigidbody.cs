using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class DragRigidbody : MonoBehaviour
    {
        const float k_Spring = 500.0f;
        const float k_Damper = 5.0f;
        const float k_Drag = 10.0f;
        const float k_AngularDrag = 5.0f;
        const float k_Distance = 0.2f;
        const bool k_AttachToCenterOfMass = false;

        private SpringJoint m_SpringJoint;
        public float turnSpeed = 3;

        private float zRot = 0;
        private void Update()
        {
            // Make sure the user pressed the mouse down
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            var mainCamera = FindCamera();

            // We need to actually hit an object
            RaycastHit hit = new RaycastHit();
            if (
                !Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                                 mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                                 Physics.DefaultRaycastLayers))
            {
                return;
            }
            // We need to hit a rigidbody that is not kinematic
            if (!hit.rigidbody || hit.rigidbody.isKinematic || hit.rigidbody.gameObject.layer != 8)
            {
                return;
            }

            if (!m_SpringJoint)
            {
                var go = new GameObject("Rigidbody dragger");
                Rigidbody body = go.AddComponent<Rigidbody>();
                m_SpringJoint = go.AddComponent<SpringJoint>();
                body.isKinematic = true;
            }

            m_SpringJoint.transform.position = hit.point;
            m_SpringJoint.anchor = Vector3.zero;

            m_SpringJoint.spring = k_Spring;
            m_SpringJoint.damper = k_Damper;
            m_SpringJoint.maxDistance = k_Distance;
            m_SpringJoint.connectedBody = hit.rigidbody;

            StartCoroutine("DragObject", hit.distance);
        }


        private IEnumerator DragObject(float distance)
        {
            m_SpringJoint.connectedBody.gameObject.GetComponent<ObjectManager>().ToggleFloat();
            var oldDrag = m_SpringJoint.connectedBody.drag;
            var oldAngularDrag = m_SpringJoint.connectedBody.angularDrag;
            m_SpringJoint.connectedBody.drag = k_Drag;
            m_SpringJoint.connectedBody.angularDrag = k_AngularDrag;
            var mainCamera = FindCamera();
            bool dragging = true;
            while (Input.GetMouseButton(0) && dragging)
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                m_SpringJoint.transform.position = ray.GetPoint(distance);
                m_SpringJoint.connectedBody.gameObject.GetComponent<Rigidbody>().useGravity = false;
                if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
                {
                    m_SpringJoint.connectedBody.gameObject.transform.RotateAround(m_SpringJoint.transform.position, Vector3.forward, turnSpeed * Time.deltaTime);
                    zRot = m_SpringJoint.connectedBody.gameObject.transform.rotation.z;
                }
                else if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.RightArrow))
                {
                    m_SpringJoint.connectedBody.gameObject.transform.RotateAround(m_SpringJoint.transform.position, Vector3.back, turnSpeed * Time.deltaTime);
                    zRot = m_SpringJoint.connectedBody.gameObject.transform.rotation.z;
                }
                Debug.Log(zRot);
                if (m_SpringJoint.connectedBody.gameObject.layer == 9)
                    dragging = false;
                yield return null;
            }
            if (m_SpringJoint.connectedBody)
            {
                m_SpringJoint.connectedBody.drag = oldDrag;
                m_SpringJoint.connectedBody.angularDrag = oldAngularDrag;
                m_SpringJoint.connectedBody.velocity = new Vector3(0, 0, 0);
                //m_SpringJoint.connectedBody.gameObject.layer = 9;
                m_SpringJoint.connectedBody.gameObject.GetComponent<Rigidbody>().useGravity = true;
                zRot = 0;
                m_SpringJoint.connectedBody = null;
            }
        }


        private Camera FindCamera()
        {
            if (GetComponent<Camera>())
            {
                return GetComponent<Camera>();
            }

            return Camera.main;
        }
    }
}
