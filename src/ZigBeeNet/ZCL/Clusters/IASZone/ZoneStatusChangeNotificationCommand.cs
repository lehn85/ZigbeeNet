﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.IASZone;

/**
 * Zone Status Change Notification Command value object class.
 *
 * Cluster: IAS Zone. Command is sentFROM the server.
 * This command is a specific command used for the IAS Zone cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters.IASZone
{
   public class ZoneStatusChangeNotificationCommand : ZclCommand
   {
           /**
           * Zone Status command message field.
           */
           public ushort ZoneStatus { get; set; }

           /**
           * Extended Status command message field.
           */
           public byte ExtendedStatus { get; set; }


           /**
           * Default constructor.
           */
           public ZoneStatusChangeNotificationCommand()
           {
               GenericCommand = false;
               ClusterId = 1280;
               CommandId = 0;
               CommandDirection = ZclCommandDirection.SERVER_TO_CLIENT;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(ZoneStatus, ZclDataType.Get(DataType.ENUMERATION_16_BIT));
        serializer.Serialize(ExtendedStatus, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        ZoneStatus = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.ENUMERATION_16_BIT));
        ExtendedStatus = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("ZoneStatusChangeNotificationCommand [");
           builder.Append(base.ToString());
           builder.Append(", ZoneStatus=");
           builder.Append(ZoneStatus);
           builder.Append(", ExtendedStatus=");
           builder.Append(ExtendedStatus);
           builder.Append(']');

           return builder.ToString();
       }

   }
}
