﻿using System;
using System.Collections.Generic;
using System.Text;
using ZigBeeNet.Serialization;
using ZigBeeNet.ZCL.Protocol;

namespace ZigBeeNet.ZCL.Field
{
    public class ExtendedAttributeInformation : IZclListItemField
    {
        /**
         * The attribute identifier.
         */
        public ushort AttributeIdentifier { get; private set; }

        /**
         * The attribute data type.
         */
        public byte AttributeDataType { get; private set; }

        /**
         * True if the attribute can be read
         */
        public bool Readable { get; private set; }

        /**
         * True if the attribute can be written
         */
        public bool Writable { get; private set; }

        /**
         * True if the attribute provides reports
         */
        public bool Reportable { get; private set; }


        public void Serialize(IZigBeeSerializer serializer)
        {
            serializer.AppendZigBeeType(AttributeIdentifier, DataType.UNSIGNED_16_BIT_INTEGER);
            serializer.AppendZigBeeType(AttributeDataType, DataType.UNSIGNED_8_BIT_INTEGER);
        }

        public void Deserialize(IZigBeeDeserializer deserializer)
        {
            AttributeIdentifier = deserializer.ReadZigBeeType<ushort>(DataType.UNSIGNED_16_BIT_INTEGER);
            AttributeDataType = deserializer.ReadZigBeeType<byte>(DataType.UNSIGNED_8_BIT_INTEGER);
        }

        public override string ToString()
        {
            return "Extended Attribute Information: attributeDataType=" + AttributeDataType + ", attributeIdentifier="
                    + AttributeIdentifier + ", readable=" + Readable + ", writable=" + Writable + ", reportable";
        }
    }
}
