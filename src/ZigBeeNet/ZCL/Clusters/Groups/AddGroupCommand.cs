﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Groups;

/**
 * Add Group Command value object class.
 *
 * Cluster: Groups. Command is sentTO the server.
 * This command is a specific command used for the Groups cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters.Groups
{
   public class AddGroupCommand : ZclCommand
   {
           /**
           * Group ID command message field.
           */
           public ushort GroupID { get; set; }

           /**
           * Group Name command message field.
           */
           public string GroupName { get; set; }


           /**
           * Default constructor.
           */
           public AddGroupCommand()
           {
               GenericCommand = false;
               ClusterId = 4;
               CommandId = 0;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
    }

    public override void Serialize(ZclFieldSerializer serializer)
    {
        serializer.Serialize(GroupID, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        serializer.Serialize(GroupName, ZclDataType.Get(DataType.CHARACTER_STRING));
    }

    public override void Deserialize(ZclFieldDeserializer deserializer)
    {
        GroupID = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
        GroupName = deserializer.Deserialize<string>(ZclDataType.Get(DataType.CHARACTER_STRING));
    }

       public override string ToString()
       {
           var builder = new StringBuilder();

           builder.Append("AddGroupCommand [");
           builder.Append(base.ToString());
           builder.Append(", GroupID=");
           builder.Append(GroupID);
           builder.Append(", GroupName=");
           builder.Append(GroupName);
           builder.Append(']');

           return builder.ToString();
       }

   }
}
