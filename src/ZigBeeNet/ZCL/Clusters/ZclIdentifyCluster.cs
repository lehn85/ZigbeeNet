﻿// License text here

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZigBeeNet.DAO;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Identify;

/**
 *Identifycluster implementation (Cluster ID 0x0003).
 *
 * Attributes and commands to put a device into an Identification mode (e.g. flashing * a light), that indicates to an observer – e.g. an installer - which of several devices * it is, also to request any device that is identifying itself to respond to the initiator. * <p> * Note that this cluster cannot be disabled, and remains functional regardless of the * setting of the DeviceEnable attribute in the Basic cluster. *
 * Code is auto-generated. Modifications may be overwritten!
 */
/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclIdentifyCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0003;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Identify";

       /* Attribute constants */
       /**
        * The IdentifyTime attribute specifies the remaining length of time, in seconds, that        * the device will continue to identify itself.        * <p>        * If this attribute is set to a value other than 0x0000 then the device shall enter its        * identification procedure, in order to indicate to an observer which of several        * devices it is. It is recommended that this procedure consists of flashing a light        * with a period of 0.5 seconds. The IdentifyTime attribute shall be decremented        * every second.        * <p>        * If this attribute reaches or is set to the value 0x0000 then the device shall        * terminate its identification procedure.       */
       public static ushort ATTR_IDENTIFYTIME = 0x0000;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(1);

           ZclClusterType identify = ZclClusterType.GetValueById(ClusterType.IDENTIFY);

           attributeMap.Add(ATTR_IDENTIFYTIME, new ZclAttribute(identify, ATTR_IDENTIFYTIME, "IdentifyTime", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, true, false));

        return attributeMap;
       }

       /**
       * Default constructor to create a Identify cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclIdentifyCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

       public Task<CommandResult> SetIdentifyTime(object value)
       {
           return Write(_attributes[ATTR_IDENTIFYTIME], value);
       }

       public Task<CommandResult> GetIdentifyTimeAsync()
       {
           return Read(_attributes[ATTR_IDENTIFYTIME]);
       }
       public ushort GetIdentifyTime(long refreshPeriod)
       {
           if (_attributes[ATTR_IDENTIFYTIME].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_IDENTIFYTIME].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_IDENTIFYTIME]);
       }


       /**
       * The Identify Command
       *
        * The identify command starts or stops the receiving device identifying itself.       *
       * @param identifyTime {@link ushort} Identify Time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> IdentifyCommand(ushort identifyTime)
       {
           IdentifyCommand command = new IdentifyCommand();

       // Set the fields
           command.IdentifyTime = identifyTime;

           return Send(command);
       }

       /**
       * The Identify Query Command
       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> IdentifyQueryCommand()
       {
           IdentifyQueryCommand command = new IdentifyQueryCommand();

           return Send(command);
       }

       /**
       * The Identify Query Response
       *
        * The identify query response command is generated in response to receiving an        * Identify Query command in the case that the device is currently identifying itself.       *
       * @param identifyTime {@link ushort} Identify Time
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> IdentifyQueryResponse(ushort identifyTime)
       {
           IdentifyQueryResponse command = new IdentifyQueryResponse();

       // Set the fields
           command.IdentifyTime = identifyTime;

           return Send(command);
       }

       public override ZclCommand GetCommandFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // IDENTIFY_COMMAND
                   return new IdentifyCommand();
               case 1: // IDENTIFY_QUERY_COMMAND
                   return new IdentifyQueryCommand();
                   default:
                       return null;
           }
       }

       public ZclCommand getResponseFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // IDENTIFY_QUERY_RESPONSE
                   return new IdentifyQueryResponse();
                   default:
                       return null;
           }
       }
   }
}
