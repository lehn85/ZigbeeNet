using System;
using System.Text;
using ZigBeeNet.Transaction;
using ZigBeeNet.ZCL;
using ZigBeeNet.ZCL.Protocol;

namespace ZigBeeNet.ZDO.Command
{
    /**
    * Network Update Request value object class.
    * 
    * This command is provided to allow updating of network configuration parameters
    * or to request information from devices on network conditions in the local
    * operating environment. The destination addressing on this primitive shall be
    * unicast or broadcast to all devices for which macRxOnWhenIdle = TRUE.
    * 
    */
    public class NetworkUpdateRequest : ZdoRequest
    {
        /**
        * ScanChannels command message field.
        */
        public int ScanChannels { get; set; }

        /**
        * ScanDuration command message field.
        */
        public byte ScanDuration { get; set; }

        /**
        * ScanCount command message field.
        */
        public byte ScanCount { get; set; }

        /**
        * nwkUpdateId command message field.
        */
        public byte NwkUpdateId { get; set; }

        /**
        * nwkManagerAddr command message field.
        */
        public ushort NwkManagerAddr { get; set; }

        /**
        * Default constructor.
        */
        public NetworkUpdateRequest()
        {
            ClusterId = 0x0038;
        }

        public override void Serialize(ZclFieldSerializer serializer)
        {
            base.Serialize(serializer);

            serializer.Serialize(ScanChannels, ZclDataType.Get(DataType.BITMAP_32_BIT));
            serializer.Serialize(ScanDuration, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(ScanCount, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(NwkUpdateId, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(NwkManagerAddr, ZclDataType.Get(DataType.NWK_ADDRESS));
        }

        public override void Deserialize(ZclFieldDeserializer deserializer)
        {
            base.Deserialize(deserializer);

            ScanChannels = (int)deserializer.Deserialize(ZclDataType.Get(DataType.BITMAP_32_BIT));
            ScanDuration = (byte)deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            ScanCount = (byte)deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            NwkUpdateId = (byte)deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            NwkManagerAddr = (ushort)deserializer.Deserialize(ZclDataType.Get(DataType.NWK_ADDRESS));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("NetworkUpdateRequest [")
                   .Append(base.ToString())
                   .Append(", scanChannels=")
                   .Append(ScanChannels)
                   .Append(", scanDuration=")
                   .Append(ScanDuration)
                   .Append(", scanCount=")
                   .Append(ScanCount)
                   .Append(", nwkUpdateId=")
                   .Append(NwkUpdateId)
                   .Append(", nwkManagerAddr=")
                   .Append(NwkManagerAddr)
                   .Append(']');

            return builder.ToString();
        }

    }
}
