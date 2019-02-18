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
 *Relative humidity measurementcluster implementation (Cluster ID 0x0405).
 *
 * The server cluster provides an interface to relative humidity measurement * functionality, including configuration and provision of notifications of relative * humidity measurements. *
 * Code is auto-generated. Modifications may be overwritten!
 */
/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclRelativeHumidityMeasurementCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0405;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "Relative humidity measurement";

       /* Attribute constants */
       /**
        * MeasuredValue represents the relative humidity in % as follows:-        * <p>        * MeasuredValue = 100 x Relative humidity        * <p>        * Where 0% <= Relative humidity <= 100%, corresponding to a MeasuredValue in        * the range 0 to 0x2710.        * <p>        * The maximum resolution this format allows is 0.01%.        * <p>        * A MeasuredValue of 0xffff indicates that the measurement is invalid.        * <p>        * MeasuredValue is updated continuously as new measurements are made.       */
       public static ushort ATTR_MEASUREDVALUE = 0x0000;

       /**
        * The MinMeasuredValue attribute indicates the minimum value of MeasuredValue        * that can be measured. A value of 0xffff means this attribute is not defined       */
       public static ushort ATTR_MINMEASUREDVALUE = 0x0001;

       /**
        * The MaxMeasuredValue attribute indicates the maximum value of MeasuredValue        * that can be measured. A value of 0xffff means this attribute is not defined.        * <p>        * MaxMeasuredValue shall be greater than MinMeasuredValue.        * <p>        * MinMeasuredValue and MaxMeasuredValue define the range of the sensor.       */
       public static ushort ATTR_MAXMEASUREDVALUE = 0x0002;

       /**
        * The Tolerance attribute indicates the magnitude of the possible error that is        * associated with MeasuredValue . The true value is located in the range        * (MeasuredValue – Tolerance) to (MeasuredValue + Tolerance).       */
       public static ushort ATTR_TOLERANCE = 0x0003;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(4);

           ZclClusterType relativehumiditymeasurement = ZclClusterType.GetValueById(ClusterType.RELATIVE_HUMIDITY_MEASUREMENT);

           attributeMap.Add(ATTR_MEASUREDVALUE, new ZclAttribute(relativehumiditymeasurement, ATTR_MEASUREDVALUE, "MeasuredValue", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, true));
           attributeMap.Add(ATTR_MINMEASUREDVALUE, new ZclAttribute(relativehumiditymeasurement, ATTR_MINMEASUREDVALUE, "MinMeasuredValue", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_MAXMEASUREDVALUE, new ZclAttribute(relativehumiditymeasurement, ATTR_MAXMEASUREDVALUE, "MaxMeasuredValue", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), true, true, false, false));
           attributeMap.Add(ATTR_TOLERANCE, new ZclAttribute(relativehumiditymeasurement, ATTR_TOLERANCE, "Tolerance", ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER), false, true, false, true));

        return attributeMap;
       }

       /**
       * Default constructor to create a Relative humidity measurement cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclRelativeHumidityMeasurementCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

       public Task<CommandResult> GetMeasuredValueAsync()
       {
           return Read(_attributes[ATTR_MEASUREDVALUE]);
       }
       public ushort GetMeasuredValue(long refreshPeriod)
       {
           if (_attributes[ATTR_MEASUREDVALUE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MEASUREDVALUE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MEASUREDVALUE]);
       }

       public Task<CommandResult> SetMeasuredValueReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_MEASUREDVALUE], minInterval, maxInterval, reportableChange);
       }

       public Task<CommandResult> GetMinMeasuredValueAsync()
       {
           return Read(_attributes[ATTR_MINMEASUREDVALUE]);
       }
       public ushort GetMinMeasuredValue(long refreshPeriod)
       {
           if (_attributes[ATTR_MINMEASUREDVALUE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MINMEASUREDVALUE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MINMEASUREDVALUE]);
       }

       public Task<CommandResult> GetMaxMeasuredValueAsync()
       {
           return Read(_attributes[ATTR_MAXMEASUREDVALUE]);
       }
       public ushort GetMaxMeasuredValue(long refreshPeriod)
       {
           if (_attributes[ATTR_MAXMEASUREDVALUE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_MAXMEASUREDVALUE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_MAXMEASUREDVALUE]);
       }

       public Task<CommandResult> GetToleranceAsync()
       {
           return Read(_attributes[ATTR_TOLERANCE]);
       }
       public ushort GetTolerance(long refreshPeriod)
       {
           if (_attributes[ATTR_TOLERANCE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_TOLERANCE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_TOLERANCE]);
       }

       public Task<CommandResult> SetToleranceReporting(ushort minInterval, ushort maxInterval, object reportableChange)
       {
           return SetReporting(_attributes[ATTR_TOLERANCE], minInterval, maxInterval, reportableChange);
       }

   }
}
