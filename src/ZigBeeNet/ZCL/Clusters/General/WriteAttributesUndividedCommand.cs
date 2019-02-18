﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.General;

/**
 * Write Attributes Undivided Command value object class.
 *
 * Cluster: General. Command is sentTO the server.
 * This command is a generic command used across the profile.
 *
 * The write attributes undivided command is generated when a device wishes to * change the values of one or more attributes located on another device, in such a * way that if any attribute cannot be written (e.g. if an attribute is not implemented * on the device, or a value to be written is outside its valid range), no attribute * values are changed. * <br> * In all other respects, including generation of a write attributes response command, * the format and operation of the command is the same as that of the write attributes * command, except that the command identifier field shall be set to indicate the * write attributes undivided command. *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters.General
{
   public class WriteAttributesUndividedCommand : ZclCommand
   {
           /**
           * Records command message field.
           */
           public List<WriteAttributeRecord> Records { get; set; }


           /**
           * Default constructor.
           */
           public WriteAttributesUndividedCommand()
           {
               GenericCommand = true;
               CommandId = 3;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(Records, ZclDataType.Get(DataType.N_X_WRITE_ATTRIBUTE_RECORD));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        Records = deserializer.Deserialize<List<WriteAttributeRecord>>(ZclDataType.Get(DataType.N_X_WRITE_ATTRIBUTE_RECORD));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("WriteAttributesUndividedCommand [");
           builder.Append(base.ToString());
           builder.Append(", Records=");
           builder.Append(Records);
           builder.Append(']');

           return builder.ToString();
       }

   }
}
