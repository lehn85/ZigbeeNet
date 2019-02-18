﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Scenes;

/**
 * Store Scene Command value object class.
 *
 * Cluster: Scenes. Command is sentTO the server.
 * This command is a specific command used for the Scenes cluster.
 *
 * The Store Scene command may be addressed to a single device or to a group. *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters.Scenes
{
   public class StoreSceneCommand : ZclCommand
   {
           /**
           * Group ID command message field.
           */
           public ushort GroupID { get; set; }

           /**
           * Scene ID command message field.
           */
           public byte SceneID { get; set; }


           /**
           * Default constructor.
           */
           public StoreSceneCommand()
           {
               GenericCommand = false;
               ClusterId = 5;
               CommandId = 4;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(GroupID, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        serializer.Serialize(SceneID, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        GroupID = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        SceneID = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("StoreSceneCommand [");
           builder.Append(base.ToString());
           builder.Append(", GroupID=");
           builder.Append(GroupID);
           builder.Append(", SceneID=");
           builder.Append(SceneID);
           builder.Append(']');

           return builder.ToString();
       }

   }
}
