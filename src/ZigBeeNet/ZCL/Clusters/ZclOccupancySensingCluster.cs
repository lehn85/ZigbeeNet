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

/**
 *Occupancy sensingcluster implementation (Cluster ID 0x0406).
 *
 * The cluster provides an interface to occupancy sensing functionality, * including configuration and provision of notifications of occupancy status. *
 * Code is auto-generated. Modifications may be overwritten!
 */
/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclOccupancySensingCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0406;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Occupancy sensing";

       /* Attribute constants */
       /**
        * The Occupancy attribute is a bitmap.        * <p>        * Bit 0 specifies the sensed occupancy as follows: 1 = occupied, 0 = unoccupied.        * All other bits are reserved.       */
       public static ushort ATTR_OCCUPANCY = 0x0000;

       /**
        * The OccupancySensorType attribute specifies the type of the occupancy sensor.       */
       public static ushort ATTR_OCCUPANCYSENSORTYPE = 0x0001;

       /**
        * The PIROccupiedToUnoccupiedDelay attribute is 8-bits in length and specifies        * the time delay, in seconds, before the PIR sensor changes to its occupied state        * when the sensed area becomes unoccupied. This attribute, along with        * PIRUnoccupiedToOccupiedTime, may be used to reduce sensor 'chatter' when        * used in an area where occupation changes frequently.       */
       public static ushort ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY = 0x0010;

       /**
        * The PIRUnoccupiedToOccupiedDelay attribute is 8-bits in length and specifies        * the time delay, in seconds, before the PIR sensor changes to its unoccupied state        * when the sensed area becomes occupied.       */
       public static ushort ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY = 0x0011;

       /**
        * The UltraSonicOccupiedToUnoccupiedTime attribute specifies the time delay, in        * seconds, before the ultrasonic sensor changes to its occupied state when the        * sensed area becomes unoccupied. This attribute, along with        * UltraSonicUnoccupiedToOccupiedTime, may be used to reduce sensor 'chatter'        * when used in an area where occupation changes frequently.       */
       public static ushort ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY = 0x0020;

       /**
        * The UltraSonicUnoccupiedToOccupiedTime attribute specifies the time delay, in        * seconds, before the ultrasonic sensor changes to its unoccupied state when the        * sensed area becomes occupied.       */
       public static ushort ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY = 0x0021;

       /**
       */
       public static ushort ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD = 0x0022;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(7);

           ZclClusterType occupancysensing = ZclClusterType.GetValueById(ClusterType.OCCUPANCY_SENSING);

           attributeMap.Add(ATTR_OCCUPANCY, new ZclAttribute(occupancysensing, ATTR_OCCUPANCY, "Occupancy", ZclDataType.Get(DataType.BITMAP_8_BIT), true, true, false, true));
           attributeMap.Add(ATTR_OCCUPANCYSENSORTYPE, new ZclAttribute(occupancysensing, ATTR_OCCUPANCYSENSORTYPE, "OccupancySensorType", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, false, false));
           attributeMap.Add(ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY, new ZclAttribute(occupancysensing, ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY, "PIROccupiedToUnoccupiedDelay", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, true, false));
           attributeMap.Add(ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY, new ZclAttribute(occupancysensing, ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY, "PIRUnoccupiedToOccupiedDelay", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, true, false));
           attributeMap.Add(ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY, new ZclAttribute(occupancysensing, ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY, "UltraSonicOccupiedToUnoccupiedDelay", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, true, false));
           attributeMap.Add(ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY, new ZclAttribute(occupancysensing, ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY, "UltraSonicUnoccupiedToOccupiedDelay", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, true, false));
           attributeMap.Add(ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD, new ZclAttribute(occupancysensing, ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD, "UltrasonicUnoccupiedToOccupiedThreshold", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, true, false));

        return attributeMap;
       }

       /**
       * Default constructor to create a Occupancy sensing cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclOccupancySensingCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

       public Task<CommandResult> GetOccupancyAsync()
       {
           return Read(_attributes[ATTR_OCCUPANCY]);
       }
       public byte GetOccupancy(long refreshPeriod)
       {
           if (_attributes[ATTR_OCCUPANCY].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_OCCUPANCY].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_OCCUPANCY]);
       }

       public Task<CommandResult> SetOccupancyReporting(ushort minInterval, ushort maxInterval)
       {
           return SetReporting(_attributes[ATTR_OCCUPANCY], minInterval, maxInterval);
       }

       public Task<CommandResult> GetOccupancySensorTypeAsync()
       {
           return Read(_attributes[ATTR_OCCUPANCYSENSORTYPE]);
       }
       public byte GetOccupancySensorType(long refreshPeriod)
       {
           if (_attributes[ATTR_OCCUPANCYSENSORTYPE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_OCCUPANCYSENSORTYPE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_OCCUPANCYSENSORTYPE]);
       }

       public Task<CommandResult> SetPIROccupiedToUnoccupiedDelay(object value)
       {
           return Write(_attributes[ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY], value);
       }

       public Task<CommandResult> GetPIROccupiedToUnoccupiedDelayAsync()
       {
           return Read(_attributes[ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY]);
       }
       public byte GetPIROccupiedToUnoccupiedDelay(long refreshPeriod)
       {
           if (_attributes[ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_PIROCCUPIEDTOUNOCCUPIEDDELAY]);
       }

       public Task<CommandResult> SetPIRUnoccupiedToOccupiedDelay(object value)
       {
           return Write(_attributes[ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY], value);
       }

       public Task<CommandResult> GetPIRUnoccupiedToOccupiedDelayAsync()
       {
           return Read(_attributes[ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY]);
       }
       public byte GetPIRUnoccupiedToOccupiedDelay(long refreshPeriod)
       {
           if (_attributes[ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_PIRUNOCCUPIEDTOOCCUPIEDDELAY]);
       }

       public Task<CommandResult> SetUltraSonicOccupiedToUnoccupiedDelay(object value)
       {
           return Write(_attributes[ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY], value);
       }

       public Task<CommandResult> GetUltraSonicOccupiedToUnoccupiedDelayAsync()
       {
           return Read(_attributes[ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY]);
       }
       public byte GetUltraSonicOccupiedToUnoccupiedDelay(long refreshPeriod)
       {
           if (_attributes[ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ULTRASONICOCCUPIEDTOUNOCCUPIEDDELAY]);
       }

       public Task<CommandResult> SetUltraSonicUnoccupiedToOccupiedDelay(object value)
       {
           return Write(_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY], value);
       }

       public Task<CommandResult> GetUltraSonicUnoccupiedToOccupiedDelayAsync()
       {
           return Read(_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY]);
       }
       public byte GetUltraSonicUnoccupiedToOccupiedDelay(long refreshPeriod)
       {
           if (_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDDELAY]);
       }

       public Task<CommandResult> SetUltrasonicUnoccupiedToOccupiedThreshold(object value)
       {
           return Write(_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD], value);
       }

       public Task<CommandResult> GetUltrasonicUnoccupiedToOccupiedThresholdAsync()
       {
           return Read(_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD]);
       }
       public byte GetUltrasonicUnoccupiedToOccupiedThreshold(long refreshPeriod)
       {
           if (_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ULTRASONICUNOCCUPIEDTOOCCUPIEDTHRESHOLD]);
       }

   }
}
