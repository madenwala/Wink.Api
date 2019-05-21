using System;
using System.Collections.Generic;
using System.Text;

namespace Wink.Api.Models
{
    public abstract class BaseDevice : WinkPubNubModelBase
    {
        public string object_type { get; set; }
        public string object_id { get; set; }
    }

    public sealed class DeviceAirConditioner : BaseDevice
    {
    }

    public sealed class DeviceBinarySwitch : BaseDevice
    {
    }

    public sealed class DeviceBlind : BaseDevice
    {
    }

    public sealed class DeviceCamera : BaseDevice
    {
    }

    public sealed class DeviceDoorbell : BaseDevice
    {
    }

    public sealed class DeviceGarageDoor : BaseDevice
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

    public sealed class DeviceAlarm : BaseDevice
    {
    }

    public sealed class DevicePowerStrip : BaseDevice
    {
    }

    public sealed class DevicePiggyBank : BaseDevice
    {
    }

    public sealed class DeviceDeposits : BaseDevice
    {
    }

    public sealed class DeviceRefridgerators : BaseDevice
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

    public sealed class DeviceSirens : BaseDevice
    {
    }

    public sealed class DeviceSmokeAlarm : BaseDevice
    {
    }

    public sealed class DeviceSprinklers : BaseDevice
    {
    }

    public sealed class DeviceThermostats : BaseDevice
    {
    }

    public sealed class DeviceWaterHeaters : BaseDevice
    {
    }
}
