using System;
using System.Collections.Generic;
using System.Text;

namespace Wink.Api.Models
{
    public abstract class DeviceBase : WinkPubNubModelBase
    {
        public string object_type { get; set; }
        public string object_id { get; set; }
    }

    public sealed class DeviceAirConditioner : DeviceBase
    {
    }

    public sealed class DeviceBinarySwitch : DeviceBase
    {
    }

    public sealed class DeviceBlind : DeviceBase
    {
    }

    public sealed class DeviceCamera : DeviceBase
    {
    }

    public sealed class DeviceDoorbell : DeviceBase
    {
    }

    public sealed class DeviceGarageDoor : DeviceBase
    {
    }

    public sealed class DeviceHub : DeviceBase
    {
    }

    public sealed class DeviceLightBulb : DeviceBase
    {
    }

    public sealed class DeviceLock : DeviceBase
    {
    }

    public sealed class DeviceNimbus : DeviceBase
    {
    }

    public sealed class DeviceNimbusAlarm : DeviceBase
    {
    }

    public sealed class DeviceAlarm : DeviceBase
    {
    }

    public sealed class DevicePowerStrip : DeviceBase
    {
    }

    public sealed class DevicePiggyBank : DeviceBase
    {
    }

    public sealed class DeviceDeposits : DeviceBase
    {
    }

    public sealed class DeviceRefridgerators : DeviceBase
    {
    }

    public sealed class DeviceRefuel : DeviceBase
    {
    }

    public sealed class DeviceRemote : DeviceBase
    {
    }

    public sealed class DeviceSensor : DeviceBase
    {
    }

    public sealed class DeviceSirens : DeviceBase
    {
    }

    public sealed class DeviceSmokeAlarm : DeviceBase
    {
    }

    public sealed class DeviceSprinklers : DeviceBase
    {
    }

    public sealed class DeviceThermostats : DeviceBase
    {
    }

    public sealed class DeviceWaterHeaters : DeviceBase
    {
    }
}
