﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Alarms;

/**
 * Get Alarm Command value object class.
 *
 * Cluster: Alarms. Command is sentTO the server.
 * This command is a specific command used for the Alarms cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters.Alarms
{
   public class GetAlarmCommand : ZclCommand
   {

           /**
           * Default constructor.
           */
           public GetAlarmCommand()
           {
               GenericCommand = false;
               ClusterId = 9;
               CommandId = 2;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("GetAlarmCommand [");
           builder.Append(base.ToString());
           builder.Append(']');

           return builder.ToString();
       }

   }
}
