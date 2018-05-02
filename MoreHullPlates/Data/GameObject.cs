using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utilites.Logger;

namespace MoreHullPlates
{
    public class GameObject
    {
        public static UnityEngine.GameObject Get(TechType techtype, string Classid, Texture2D texture)
        {
            try
            {
                var prefab = Resources.Load<UnityEngine.GameObject>("Submarine/Build/IGPHullPlate");
                var obj = UnityEngine.Object.Instantiate(prefab);
                var child = obj.transform.Find("Icon").gameObject;

                var constructable = obj.GetComponent<Constructable>();
                var techTag = obj.GetComponent<TechTag>();
                var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();
                var mesh = child.GetComponent<MeshRenderer>();
                var iconpos = child.GetComponent<Transform>();

                constructable.techType = techtype;
                constructable.allowedInBase = true;
                constructable.allowedInSub = true;
                constructable.allowedOutside = false;
                constructable.allowedOnCeiling = false;
                constructable.allowedOnConstructables = false;
                constructable.allowedOnGround = false;
                constructable.allowedOnWall = true;
                constructable.controlModelState = true;
                constructable.forceUpright = false;
                constructable.rotationEnabled = false;
                constructable.deconstructionAllowed = true;
                constructable.placeMaxDistance = 5;
                constructable.placeMinDistance = 1.2f;
                constructable.placeDefaultDistance = 2;
                constructable.surfaceType = VFXSurfaceTypes.metal;

                techTag.type = techtype;

                prefabIdentifier.ClassId = Classid;

                mesh.material.mainTexture = texture;

                return obj;
            }
            catch (Exception e)
            {
                e.Log();
                return null;
            }
        }
    }
}
