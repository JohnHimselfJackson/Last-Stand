using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class BulletManager : MonoBehaviour
{
    public static EntityManager manager;

    public static EntityArchetype myBullet;
    public Mesh mesh; //add a plane mesh
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        myBullet = manager.CreateArchetype(typeof(Translation), typeof(RenderMesh), typeof(RenderBounds), typeof(Firing), typeof(LocalToWorld), typeof(Scale));
        // Vector3 myScale = (0.04f, 1f, 0.6f); typeof(Rotation)
    }
    public void  CreateBullet(Vector3 myPos, Vector3 enemyPos)
    {
        myPos.y = 0.2f;
        Entity entity = manager.CreateEntity(myBullet);
        for (int i = 0; i < 1; i++)
        {

            manager.SetSharedComponentData(entity, new RenderMesh
            {        
                
                mesh = mesh,               
                material = material,
    
            }) ;
            manager.SetComponentData(entity, new Scale { Value = 0.01f });
            manager.SetComponentData(entity, new Translation { Value = myPos });
            //manager.SetComponentData(entity, new Rotation { Value = quaternion.Euler(90f, 0f, 0f) });
            manager.SetComponentData(entity, new Firing { firePos = enemyPos });
           
           
        }
       
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        for (int i = 0; i < maxBullets; i++;){
    //            var instance = manager.Instantiate(); //line renderer
    //            manager.SetComponentData(instance, new Translation { Value = Vector3.zero });
    //            manager.SetComponentData(instance, new LineRenderer { });
    //        }
    //    }

    //    line.se
    //}

    //void Shoot()
    //{
    //    line.SetPosition(0,
    //}
}
