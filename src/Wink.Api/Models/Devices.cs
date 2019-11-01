using System;
using System.Collections.Generic;
using System.Text;

namespace Wink.Api.Models
{
    internal static class KnownObjectTypes
    {
        internal const string UnknownDevice = "unknown_device";

        internal const string AirConditioner = null;
        internal const string Alarm = null;
        internal const string BinanarySwitch = "binary_switch";
        internal const string Blind = null;
        internal const string Button = "button";
        internal const string Deposits = null;
        internal const string Doorbell = "door_bell";
        internal const string EggTray = "eggtray";
        internal const string Gang = "gang";
        internal const string GarageDoor = null;
        internal const string Hub = "hub";
        internal const string LightBulb = "light_bulb";
        internal const string Lock = "lock";
        internal const string Nimbus = null;
        internal const string NimbusAlarm = null;
        internal const string PiggyBank = null;
        internal const string Refridgerator = null;
        internal const string Refuel = null;
        internal const string Remote = "remote";
        internal const string Sensor = "sensor_pod";
        internal const string Siren = "siren";
        internal const string SmokeAlarm = null;
        internal const string Sprinker = null;
        internal const string Thermostat = "thermostat";
        internal const string WaterHeater = null;
    }

    public abstract class BaseDevice : WinkPubNubModelBase
    {
        public string object_type { get; set; }
        public string object_id { get; set; }
    }

    public sealed class DeviceAirConditioner : BaseDevice
    {
    }

    public sealed class DeviceAlarm : BaseDevice
    {
    }

    public sealed class DeviceBinarySwitch : BaseDevice
    {
    }

    public sealed class DeviceBlind : BaseDevice
    {
    }

    public sealed class DeviceButton : BaseDevice
    {
    }

    public sealed class DeviceDeposits : BaseDevice
    {
    }

    public sealed class DeviceDoorbell : BaseDevice
    {
    }

    public sealed class DeviceEggtray : BaseDevice
    {
    }

    public sealed class DeviceGarageDoor : BaseDevice
    {
    }

    public sealed class DeviceGang : BaseDevice
    {
    }

    public sealed class DeviceHub : BaseDevice
    {
    }

    public sealed class DeviceLightBulb : BaseDevice
    {
    }

    public sealed class DeviceLock : BaseDevice
    {
    }

    public sealed class DeviceNimbus : BaseDevice
    {
    }

    public sealed class DeviceNimbusAlarm : BaseDevice
    {
    }

    public sealed class DevicePowerStrip : BaseDevice
    {
    }

    public sealed class DevicePiggyBank : BaseDevice
    {
    }

    public sealed class DeviceRefridgerator : BaseDevice
    {
    }

    public sealed class DeviceRefuel : BaseDevice
    {
    }

    public sealed class DeviceRemote : BaseDevice
    {
    }

    public sealed class DeviceSensor : BaseDevice
    {
    }

    public sealed class DeviceSiren : BaseDevice
    {
    }

    public sealed class DeviceSmokeAlarm : BaseDevice
    {
    }

    public sealed class DeviceSprinkler : BaseDevice
    {
    }

    public sealed class DeviceThermostat : BaseDevice
    {
    }

    public sealed class DeviceUnknown : BaseDevice
    {
    }

    public sealed class DeviceWaterHeater : BaseDevice
    {
    }
}
