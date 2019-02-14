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
using ZigBeeNet.ZCL.Clusters.IASZone;

/**
 *IAS Zonecluster implementation (Cluster ID 0x0500).
 *
 * The IAS Zone cluster defines an interface to the functionality of an IAS security * zone device. IAS Zone supports up to two alarm types per zone, low battery * reports and supervision of the IAS network. *
 * Code is auto-generated. Modifications may be overwritten!
 */
/* Autogenerated: 14.02.2019 - 18:41 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclIASZoneCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0500;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "IAS Zone";

       /* Attribute constants */
       /**
        * The Zone State attribute defines if the device is currently enrolled with a CIE or not.       */
       public static ushort ATTR_ZONESTATE = 0x0000;

       /**
        * The Zone Type dictates the meaning of Alarm1 and Alarm2 bits of the ZoneStatus attribute       */
       public static ushort ATTR_ZONETYPE = 0x0001;

       /**
        * The ZoneStatus attribute is a bit map. Each bit defines the state of an alarm.       */
       public static ushort ATTR_ZONESTATUS = 0x0002;

       /**
        * The IAS_CIE_Address attribute specifies the address that commands generated by        * the server shall be sent to. All commands received by the server must also come        * from this address.        * <p>        * It is up to the zone's specific implementation to permit or deny change (write) of        * this attribute at specific times. Also, it is up to the zone's specific implementation        * to implement some auto-detect for the CIE (example: by requesting the ZigBee        * cluster discovery service to locate a Zone Server cluster.) or require the        * intervention of a CT in order to configure this attribute during installation.       */
       public static ushort ATTR_IASCIEADDRESS = 0x0010;

       /**
        * A unique reference number allocated by the CIE at zone enrollment time.        * <p>        * Used by IAS devices to reference specific zones when communicating with the CIE. The ZoneID of each zone stays fixed until that zone is
        * unenrolled.       */
       public static ushort ATTR_ZONEID = 0x0011;

       /**
        * Provides the total number of sensitivity levels supported by the IAS Zone server. The purpose of this attribute is to support devices that
        * can be configured to be more or less sensitive (e.g., motion sensor). It provides IAS Zone clients with the range of sensitivity levels that
        * are supported so they MAY be presented to the user for configuration.        * <p>        * The values 0x00 and 0x01 are reserved because a device that has zero or one sensitivity level SHOULD NOT support this attribute because no
        * configuration of the IAS Zone server’s sensitivity level is possible.        * <p>        * The meaning of each sensitivity level is manufacturer-specific. However, the sensitivity level of the IAS Zone server SHALL become more
        * sensitive as they ascend. For example, if the server supports three sen- sitivity levels, then the value of this attribute would be 0x03
        * where 0x03 is more sensitive than 0x02, which is more sensitive than 0x01.       */
       public static ushort ATTR_NUMBEROFZONESENSITIVITYLEVELSSUPPORTED = 0x0012;

       /**
        * Allows an IAS Zone client to query and configure the IAS Zone server’s sensitivity level. Please see
        * NumberOfZoneSensitivityLevelsSupported Attribute for more detail on how to interpret this attribute.        * <p>        * The default value 0x00 is the device’s default sensitivity level as configured by the manufacturer. It MAY correspond to the same
        * sensitivity as another value in the NumberOfZoneSensitivityLevelsSupported, but this is the default sensitivity to be used if the
        * CurrentZoneSensitivityLevel attribute is not otherwise configured by an IAS Zone client.       */
       public static ushort ATTR_CURRENTZONESENSITIVITYLEVEL = 0x0013;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(7);

           ZclClusterType iASZone = ZclClusterType.GetValueById(ClusterType.IAS_ZONE);

           attributeMap.Add(ATTR_ZONESTATE, new ZclAttribute(iASZone, ATTR_ZONESTATE, "ZoneState", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, false, false));
           attributeMap.Add(ATTR_ZONETYPE, new ZclAttribute(iASZone, ATTR_ZONETYPE, "ZoneType", ZclDataType.Get(DataType.ENUMERATION_16_BIT), true, true, false, false));
           attributeMap.Add(ATTR_ZONESTATUS, new ZclAttribute(iASZone, ATTR_ZONESTATUS, "ZoneStatus", ZclDataType.Get(DataType.BITMAP_16_BIT), true, true, false, false));
           attributeMap.Add(ATTR_IASCIEADDRESS, new ZclAttribute(iASZone, ATTR_IASCIEADDRESS, "IASCIEAddress", ZclDataType.Get(DataType.IEEE_ADDRESS), true, true, true, false));
           attributeMap.Add(ATTR_ZONEID, new ZclAttribute(iASZone, ATTR_ZONEID, "ZoneID", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), true, true, true, false));
           attributeMap.Add(ATTR_NUMBEROFZONESENSITIVITYLEVELSSUPPORTED, new ZclAttribute(iASZone, ATTR_NUMBEROFZONESENSITIVITYLEVELSSUPPORTED, "NumberOfZoneSensitivityLevelsSupported", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, false, false));
           attributeMap.Add(ATTR_CURRENTZONESENSITIVITYLEVEL, new ZclAttribute(iASZone, ATTR_CURRENTZONESENSITIVITYLEVEL, "CurrentZoneSensitivityLevel", ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER), false, true, true, false));

        return attributeMap;
       }

       /**
       * Default constructor to create a IAS Zone cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclIASZoneCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

       public Task<CommandResult> GetZoneStateAsync()
       {
           return Read(_attributes[ATTR_ZONESTATE]);
       }
       public byte GetZoneState(long refreshPeriod)
       {
           if (_attributes[ATTR_ZONESTATE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ZONESTATE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ZONESTATE]);
       }

       public Task<CommandResult> GetZoneTypeAsync()
       {
           return Read(_attributes[ATTR_ZONETYPE]);
       }
       public ushort GetZoneType(long refreshPeriod)
       {
           if (_attributes[ATTR_ZONETYPE].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ZONETYPE].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ZONETYPE]);
       }

       public Task<CommandResult> GetZoneStatusAsync()
       {
           return Read(_attributes[ATTR_ZONESTATUS]);
       }
       public ushort GetZoneStatus(long refreshPeriod)
       {
           if (_attributes[ATTR_ZONESTATUS].IsLastValueCurrent(refreshPeriod))
           {
               return (ushort)_attributes[ATTR_ZONESTATUS].LastValue;
           }

           return (ushort)ReadSync(_attributes[ATTR_ZONESTATUS]);
       }

       public Task<CommandResult> SetIASCIEAddress(object value)
       {
           return Write(_attributes[ATTR_IASCIEADDRESS], value);
       }

       public Task<CommandResult> GetIASCIEAddressAsync()
       {
           return Read(_attributes[ATTR_IASCIEADDRESS]);
       }
       public IeeeAddress GetIASCIEAddress(long refreshPeriod)
       {
           if (_attributes[ATTR_IASCIEADDRESS].IsLastValueCurrent(refreshPeriod))
           {
               return (IeeeAddress)_attributes[ATTR_IASCIEADDRESS].LastValue;
           }

           return (IeeeAddress)ReadSync(_attributes[ATTR_IASCIEADDRESS]);
       }

       public Task<CommandResult> SetZoneID(object value)
       {
           return Write(_attributes[ATTR_ZONEID], value);
       }

       public Task<CommandResult> GetZoneIDAsync()
       {
           return Read(_attributes[ATTR_ZONEID]);
       }
       public byte GetZoneID(long refreshPeriod)
       {
           if (_attributes[ATTR_ZONEID].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_ZONEID].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_ZONEID]);
       }

       public Task<CommandResult> GetNumberOfZoneSensitivityLevelsSupportedAsync()
       {
           return Read(_attributes[ATTR_NUMBEROFZONESENSITIVITYLEVELSSUPPORTED]);
       }
       public byte GetNumberOfZoneSensitivityLevelsSupported(long refreshPeriod)
       {
           if (_attributes[ATTR_NUMBEROFZONESENSITIVITYLEVELSSUPPORTED].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_NUMBEROFZONESENSITIVITYLEVELSSUPPORTED].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_NUMBEROFZONESENSITIVITYLEVELSSUPPORTED]);
       }

       public Task<CommandResult> SetCurrentZoneSensitivityLevel(object value)
       {
           return Write(_attributes[ATTR_CURRENTZONESENSITIVITYLEVEL], value);
       }

       public Task<CommandResult> GetCurrentZoneSensitivityLevelAsync()
       {
           return Read(_attributes[ATTR_CURRENTZONESENSITIVITYLEVEL]);
       }
       public byte GetCurrentZoneSensitivityLevel(long refreshPeriod)
       {
           if (_attributes[ATTR_CURRENTZONESENSITIVITYLEVEL].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_CURRENTZONESENSITIVITYLEVEL].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_CURRENTZONESENSITIVITYLEVEL]);
       }


       /**
       * The Zone Enroll Response
       *
       * @param enrollResponseCode {@link byte} Enroll response code
       * @param zoneID {@link byte} Zone ID
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> ZoneEnrollResponse(byte enrollResponseCode, byte zoneID)
       {
           ZoneEnrollResponse command = new ZoneEnrollResponse();

       // Set the fields
           command.EnrollResponseCode = enrollResponseCode;
           command.ZoneID = zoneID;

           return Send(command);
       }

       /**
       * The Initiate Normal Operation Mode Command
       *
        * Used to tell the IAS Zone server to commence normal operation mode.        * <br>        * Upon receipt, the IAS Zone server SHALL commence normal operational mode.        * <br>        * Any configurations and changes made (e.g., CurrentZoneSensitivityLevel attribute) to the IAS Zone server SHALL be retained.        * <br>        * Upon commencing normal operation mode, the IAS Zone server SHALL send a Zone Status Change Notification command updating the ZoneStatus
        * attribute Test bit to zero (i.e., “operation mode”).       *
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> InitiateNormalOperationModeCommand()
       {
           InitiateNormalOperationModeCommand command = new InitiateNormalOperationModeCommand();

           return Send(command);
       }

       /**
       * The Initiate Test Mode Command
       *
        * Certain IAS Zone servers MAY have operational configurations that could be configured OTA or locally on the device. This command enables
        * them to be remotely placed into a test mode so that the user or installer MAY configure their field of view, sensitivity, and other
        * operational parameters. They MAY also verify the placement and proper operation of the IAS Zone server, which MAY have been placed in a
        * difficult to reach location (i.e., making a physical input on the device impractical to trigger).        * <br>        * Another use case for this command is large deployments, especially commercial and industrial, where placing the entire IAS system into
        * test mode instead of a single IAS Zone server is infeasible due to the vulnerabilities that might arise. This command enables only a single
        * IAS Zone server to be placed into test mode.        * <br>        * The biggest limitation of this command is that most IAS Zone servers today are battery-powered sleepy nodes that cannot reliably receive
        * commands. However, implementers MAY decide to program an IAS Zone server by factory default to maintain a limited duration of normal
        * polling upon initialization/joining to a new network. Some IAS Zone servers MAY also have AC mains power and are able to receive commands.
        * Some types of IAS Zone servers that MAY benefit from this command are: motion sensors and fire sensor/smoke alarm listeners (i.e., a device
        * that listens for a non-communicating fire sensor to alarm and communicates this to the IAS CIE).       *
       * @param testModeDuration {@link byte} Test Mode Duration
       * @param currentZoneSensitivityLevel {@link byte} Current Zone Sensitivity Level
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> InitiateTestModeCommand(byte testModeDuration, byte currentZoneSensitivityLevel)
       {
           InitiateTestModeCommand command = new InitiateTestModeCommand();

       // Set the fields
           command.TestModeDuration = testModeDuration;
           command.CurrentZoneSensitivityLevel = currentZoneSensitivityLevel;

           return Send(command);
       }

       /**
       * The Zone Status Change Notification Command
       *
       * @param zoneStatus {@link ushort} Zone Status
       * @param extendedStatus {@link byte} Extended Status
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> ZoneStatusChangeNotificationCommand(ushort zoneStatus, byte extendedStatus)
       {
           ZoneStatusChangeNotificationCommand command = new ZoneStatusChangeNotificationCommand();

       // Set the fields
           command.ZoneStatus = zoneStatus;
           command.ExtendedStatus = extendedStatus;

           return Send(command);
       }

       /**
       * The Zone Enroll Request Command
       *
        * The Zone Enroll Request command is generated when a device embodying the Zone server cluster wishes        * to be  enrolled as an active  alarm device. It  must do this immediately it has joined the network        * (during commissioning).       *
       * @param zoneType {@link ushort} Zone Type
       * @param manufacturerCode {@link ushort} Manufacturer Code
       * @return the Task<CommandResult> command result Task
       */
       public Task<CommandResult> ZoneEnrollRequestCommand(ushort zoneType, ushort manufacturerCode)
       {
           ZoneEnrollRequestCommand command = new ZoneEnrollRequestCommand();

       // Set the fields
           command.ZoneType = zoneType;
           command.ManufacturerCode = manufacturerCode;

           return Send(command);
       }

       public override ZclCommand GetCommandFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // ZONE_ENROLL_RESPONSE
                   return new ZoneEnrollResponse();
               case 1: // INITIATE_NORMAL_OPERATION_MODE_COMMAND
                   return new InitiateNormalOperationModeCommand();
               case 2: // INITIATE_TEST_MODE_COMMAND
                   return new InitiateTestModeCommand();
                   default:
                       return null;
           }
       }

       public ZclCommand getResponseFromId(int commandId)
       {
           switch (commandId)
           {
               case 0: // ZONE_STATUS_CHANGE_NOTIFICATION_COMMAND
                   return new ZoneStatusChangeNotificationCommand();
               case 1: // ZONE_ENROLL_REQUEST_COMMAND
                   return new ZoneEnrollRequestCommand();
                   default:
                       return null;
           }
       }
   }
}
