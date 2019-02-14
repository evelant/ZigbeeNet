﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.RSSILocation;

/**
 * Report RSSI Measurements Command value object class.
 *
 * Cluster: RSSI Location. Command is sentFROM the server.
 * This command is a specific command used for the RSSI Location cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 13.02.2019 - 21:42 */
namespace ZigBeeNet.ZCL.Clusters.RSSILocation
{
   public class ReportRSSIMeasurementsCommand : ZclCommand
   {
           /**
           * Reporting Address command message field.
           */
           public IeeeAddress ReportingAddress { get; set; }

           /**
           * Number of Neighbors command message field.
           */
           public byte NumberOfNeighbors { get; set; }

           /**
           * Neighbors Information command message field.
           */
           public List<NeighborInformation> NeighborsInformation { get; set; }


           /**
           * Default constructor.
           */
           public ReportRSSIMeasurementsCommand()
           {
               GenericCommand = false;
               ClusterId = 11;
               CommandId = 6;
               CommandDirection = ZclCommandDirection.SERVER_TO_CLIENT;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(ReportingAddress, ZclDataType.Get(DataType.IEEE_ADDRESS));
        serializer.Serialize(NumberOfNeighbors, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
        serializer.Serialize(NeighborsInformation, ZclDataType.Get(DataType.N_X_NEIGHBORS_INFORMATION));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        ReportingAddress = deserializer.Deserialize<IeeeAddress>(ZclDataType.Get(DataType.IEEE_ADDRESS));
        NumberOfNeighbors = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
        NeighborsInformation = deserializer.Deserialize<List<NeighborInformation>>(ZclDataType.Get(DataType.N_X_NEIGHBORS_INFORMATION));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("ReportRSSIMeasurementsCommand [");
           builder.Append(base.ToString());
           builder.Append(", ReportingAddress=");
           builder.Append(ReportingAddress);
           builder.Append(", NumberOfNeighbors=");
           builder.Append(NumberOfNeighbors);
           builder.Append(", NeighborsInformation=");
           builder.Append(NeighborsInformation);
           builder.Append(']');

           return builder.ToString();
       }

   }
}