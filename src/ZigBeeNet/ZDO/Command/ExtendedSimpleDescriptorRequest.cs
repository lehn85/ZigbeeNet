using System;
using System.Text;
using ZigBeeNet.Transaction;
using ZigBeeNet.ZCL;
using ZigBeeNet.ZCL.Protocol;

namespace ZigBeeNet.ZDO.Command
{
    /**
    * Extended Simple Descriptor Request value object class.
    * 
    * The Extended_Simple_Desc_req command is generated from a local device
    * wishing to inquire as to the simple descriptor of a remote device on a specified
    * endpoint. This command shall be unicast either to the remote device itself or to an
    * alternative device that contains the discovery information of the remote device.
    * The Extended_Simple_Desc_req is intended for use with devices which employ a
    * larger number of application input or output clusters than can be described by the
    * Simple_Desc_req.
    * 
    */
    public class ExtendedSimpleDescriptorRequest : ZdoRequest
    {
        /**
        * NWKAddrOfInterest command message field.
        */
        public ushort NwkAddrOfInterest { get; set; }

        /**
        * Endpoint command message field.
*/
        public byte Endpoint { get; set; }

        /**
        * StartIndex command message field.
*/
        public byte StartIndex { get; set; }

        /**
        * Default constructor.
*/
        public ExtendedSimpleDescriptorRequest()
        {
            ClusterId = 0x001D;
        }

        public override void Serialize(ZclFieldSerializer serializer)
        {
            base.Serialize(serializer);

            serializer.Serialize(NwkAddrOfInterest, ZclDataType.Get(DataType.NWK_ADDRESS));
            serializer.Serialize(Endpoint, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(StartIndex, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
        }

        public override void Deserialize(ZclFieldDeserializer deserializer)
        {
            base.Deserialize(deserializer);

            NwkAddrOfInterest = (ushort)deserializer.Deserialize(ZclDataType.Get(DataType.NWK_ADDRESS));
            Endpoint = (byte)deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            StartIndex = (byte)deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("ExtendedSimpleDescriptorRequest [")
                   .Append(base.ToString())
                   .Append(", nwkAddrOfInterest=")
                   .Append(NwkAddrOfInterest)
                   .Append(", endpoint=")
                   .Append(Endpoint)
                   .Append(", startIndex=")
                   .Append(StartIndex)
                   .Append(']');

            return builder.ToString();
        }

    }
}
