﻿using System;
using System.Collections.Generic;
using System.Text;
using ZigBeeNet.Transaction;
using ZigBeeNet.ZCL;
using ZigBeeNet.ZCL.Protocol;

namespace ZigBeeNet.ZDO.Command
{
    public class IeeeAddressRequest : ZdoRequest, IZigBeeTransactionMatcher
    {
        /**
         * NWKAddrOfInterest command message field.
         */
        public ushort NwkAddrOfInterest { get; set; }

        /**
         * RequestType command message field.
         */
        public byte RequestType { get; set; }

        /**
         * StartIndex command message field.
         */
        public byte StartIndex { get; set; }

        /**
         * Default constructor.
         */
        public IeeeAddressRequest()
        {
            ClusterId = 0x0001;
        }

        public override void Serialize(ZclFieldSerializer serializer)
        {
            base.Serialize(serializer);

            serializer.Serialize(NwkAddrOfInterest, ZclDataType.Get(DataType.NWK_ADDRESS));
            serializer.Serialize(RequestType, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(StartIndex, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
        }

        public override void Deserialize(ZclFieldDeserializer deserializer)
        {
            base.Deserialize(deserializer);

            NwkAddrOfInterest = (ushort)deserializer.Deserialize(ZclDataType.Get(DataType.NWK_ADDRESS));
            RequestType = (byte)deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            StartIndex = (byte)deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
        }

        public bool IsTransactionMatch(ZigBeeCommand request, ZigBeeCommand response)
        {
            if (response is IeeeAddressResponse rsp)
            { 
                return ((IeeeAddressRequest)request).NwkAddrOfInterest.Equals(rsp.NwkAddrRemoteDev);
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("IeeeAddressRequest [")
                   .Append(base.ToString())
                   .Append(", nwkAddrOfInterest=")
                   .Append(NwkAddrOfInterest)
                   .Append(", requestType=")
                   .Append(RequestType)
                   .Append(", startIndex=")
                   .Append(StartIndex)
                   .Append(']');

            return builder.ToString();
        }

    }
}
