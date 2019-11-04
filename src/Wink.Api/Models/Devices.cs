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

    #region Core Classes

    public abstract class BaseDevice : WinkModelBase
    {
        public string object_type { get; set; }
        public string object_id { get; set; }
        public Subscription subscription { get; set; }
        public string uuid { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }
        public string icon_id { get; set; }
        public string icon_code { get; set; }
        public Desired_State desired_state { get; set; }
        public string manufacturer_device_model { get; set; }
        public object manufacturer_device_id { get; set; }
        public string device_manufacturer { get; set; }
        public string model_name { get; set; }
        public string upc_id { get; set; }
        public string upc_code { get; set; }
        public string primary_upc_code { get; set; }
        public object linked_service_id { get; set; }
        public float[] lat_lng { get; set; }
        public string location { get; set; }
        public Capabilities capabilities { get; set; }
        public DeviceThermostatUnits units { get; set; }
        public string hub_id { get; set; }
        public string locale { get; set; }
    }

    public sealed class Desired_State
    {
    }

    public sealed class Subscription
    {
        public Pubnub pubnub { get; set; }
    }

    public sealed class Pubnub
    {
        public string subscribe_key { get; set; }
        public string channel { get; set; }
        public string origin { get; set; }
    }

    public sealed class Units
    {
    }

    public sealed class Capabilities
    {
        public Field[] fields { get; set; }
        public bool supports_ble { get; set; }
        public string[] oauth2_clients { get; set; }
        public bool home_security_device { get; set; }
        public bool needs_wifi_network_list { get; set; }
        public bool excludes_robot_cause { get; set; }
        public bool excludes_naming { get; set; }
        public string[] notification_robots { get; set; }
        public bool is_sleepy { get; set; }
        public bool excludes_sharing { get; set; }
        public int polling_interval { get; set; }
        public string[] lookout { get; set; }
        public bool supports_electric_imp { get; set; }
        public string required_feature_flag { get; set; }

        public Automation_Robots[] automation_robots { get; set; }
    }

    public class Field
    {
        public string type { get; set; }
        public string field { get; set; }
        public string mutability { get; set; }
        public int attribute_id { get; set; }
        public string[] choices { get; set; }
        public float clear_desired_state_tolerance { get; set; }
        public string legacy_type { get; set; }
        public string skip_serialize { get; set; }
        public int precision { get; set; }
        public int[] range { get; set; }
        public DeviceAttributeValueMapping attribute_value_mapping { get; set; }
        public string propagation { get; set; }
    }

    public class DeviceAttributeValueMapping
    {
        public string low { get; set; }
        public string high { get; set; }
        public string medium { get; set; }
        public string _30 { get; set; }
        public string _60 { get; set; }
        public string _300 { get; set; }
        public string _1 { get; set; }
        public string _true { get; set; }
        public string _false { get; set; }
        public string beep { get; set; }
        public string alert { get; set; }
        public string doorbell { get; set; }
        public string beep_beep { get; set; }
        public string fur_elise { get; set; }
        public string evacuation { get; set; }
        public string police_siren { get; set; }
        public string william_tell { get; set; }
        public string rondo_alla_turca { get; set; }
        public string doorbell_extended { get; set; }
        public string inactive { get; set; }
    }

    public class Automation_Robots
    {
        public string name { get; set; }
        public Caus[] causes { get; set; }
        public Effect[] effects { get; set; }
        public bool enabled { get; set; }
        public string automation_mode { get; set; }
    }

    public class Caus
    {
        public string value { get; set; }
        public string _operator { get; set; }
        public string observed_field { get; set; }
        public string observed_object_id { get; set; }
        public string observed_object_type { get; set; }
    }

    public class Effect
    {
        public Scene scene { get; set; }
    }

    public class Scene
    {
        public Member[] members { get; set; }
    }

    public class Member
    {
        public string object_id { get; set; }
        public string object_type { get; set; }
        public Member_Desired_State1 desired_state { get; set; }
    }

    public class Member_Desired_State1
    {
        public bool opened { get; set; }
    }

    #endregion

    #region Last Readings

    public class Last_Reading_Gang
    {
        public bool connection { get; set; }
        public float connection_updated_at { get; set; }
        public float connection_changed_at { get; set; }
    }

    public class Last_Reading_Button
    {
        public bool connection { get; set; }
        public float connection_updated_at { get; set; }
        public bool pressed { get; set; }
        public float pressed_updated_at { get; set; }
        public object long_pressed { get; set; }
        public object long_pressed_updated_at { get; set; }
        public object ifttt_connected { get; set; }
        public object ifttt_connected_updated_at { get; set; }
        public object ifttt_identifier { get; set; }
        public object ifttt_identifier_updated_at { get; set; }
        public float connection_changed_at { get; set; }
    }

    public abstract class LastReadingBase
    {
        public bool connection { get; set; }
        public float connection_updated_at { get; set; }
    }

    #endregion

    public sealed class DeviceAirConditioner : BaseDevice
    {
    }

    public sealed class DeviceAlarm : BaseDevice
    {
    }

    public sealed class DeviceBinarySwitch : BaseDevice
    {
        public DeviceBinarySwitchLastReading last_reading { get; set; }
        public string binary_switch_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object[] triggers { get; set; }
        public string gang_id { get; set; }
        public string local_id { get; set; }
        public string radio_type { get; set; }
        public object current_budget { get; set; }
        public int order { get; set; }
    }

    public class Last_Reading_BinarySwitch : LastReadingBase
    {
        public bool powered { get; set; }
        public float powered_updated_at { get; set; }
        public string powering_mode { get; set; }
        public float powering_mode_updated_at { get; set; }
        public float desired_powered_updated_at { get; set; }
        public float desired_powering_mode_updated_at { get; set; }
        public float connection_changed_at { get; set; }
        public float powered_changed_at { get; set; }
        public float powering_mode_changed_at { get; set; }
        public float desired_powered_changed_at { get; set; }
        public float desired_powering_mode_changed_at { get; set; }
        public bool opened { get; set; }
        public float opened_updated_at { get; set; }
        public object desired_opened { get; set; }
        public object desired_opened_updated_at { get; set; }
        public float opened_changed_at { get; set; }
    }

    public class DeviceBinarySwitchLastReading : LastReadingBase
    {
        public string agent_session_id { get; set; }
        public float agent_session_id_updated_at { get; set; }
        public string pairing_mode { get; set; }
        public float pairing_mode_updated_at { get; set; }
        public object pairing_device_type_selector { get; set; }
        public object pairing_device_type_selector_updated_at { get; set; }
        public int kidde_radio_code { get; set; }
        public float kidde_radio_code_updated_at { get; set; }
        public int pairing_mode_duration { get; set; }
        public float pairing_mode_duration_updated_at { get; set; }
        public string ota_image_selection { get; set; }
        public float ota_image_selection_updated_at { get; set; }
        public int ota_window_start { get; set; }
        public float ota_window_start_updated_at { get; set; }
        public int ota_window_end { get; set; }
        public float ota_window_end_updated_at { get; set; }
        public bool ota_enabled { get; set; }
        public float ota_enabled_updated_at { get; set; }
        public string[] enabled_http_modules { get; set; }
        public float enabled_http_modules_updated_at { get; set; }
        public object led_brightness { get; set; }
        public float led_brightness_updated_at { get; set; }
        public bool updating_firmware { get; set; }
        public float updating_firmware_updated_at { get; set; }
        public string firmware_version { get; set; }
        public float firmware_version_updated_at { get; set; }
        public bool update_needed { get; set; }
        public float update_needed_updated_at { get; set; }
        public string mac_address { get; set; }
        public float mac_address_updated_at { get; set; }
        public string zigbee_mac_address { get; set; }
        public float zigbee_mac_address_updated_at { get; set; }
        public string ip_address { get; set; }
        public float ip_address_updated_at { get; set; }
        public string hub_version { get; set; }
        public float hub_version_updated_at { get; set; }
        public string app_version { get; set; }
        public float app_version_updated_at { get; set; }
        public object transfer_mode { get; set; }
        public float transfer_mode_updated_at { get; set; }
        public string connection_type { get; set; }
        public float connection_type_updated_at { get; set; }
        public bool wifi_credentials_present { get; set; }
        public float wifi_credentials_present_updated_at { get; set; }
        public string bundle_id { get; set; }
        public float bundle_id_updated_at { get; set; }
        public object remote_pairable { get; set; }
        public object remote_pairable_updated_at { get; set; }
        public object[] present_devices { get; set; }
        public float present_devices_updated_at { get; set; }
        public string local_control_public_key_hash { get; set; }
        public float local_control_public_key_hash_updated_at { get; set; }
        public string local_control_id { get; set; }
        public float local_control_id_updated_at { get; set; }
        public float health { get; set; }
        public float health_updated_at { get; set; }
        public float desired_pairing_mode_updated_at { get; set; }
        public float desired_pairing_device_type_selector_updated_at { get; set; }
        public float desired_kidde_radio_code_updated_at { get; set; }
        public float desired_pairing_mode_duration_updated_at { get; set; }
        public float desired_ota_image_selection_updated_at { get; set; }
        public float desired_ota_window_start_updated_at { get; set; }
        public float desired_ota_window_end_updated_at { get; set; }
        public float desired_ota_enabled_updated_at { get; set; }
        public float desired_enabled_http_modules_updated_at { get; set; }
        public float desired_led_brightness_updated_at { get; set; }
        public float connection_changed_at { get; set; }
        public float agent_session_id_changed_at { get; set; }
        public float pairing_mode_changed_at { get; set; }
        public float kidde_radio_code_changed_at { get; set; }
        public float pairing_mode_duration_changed_at { get; set; }
        public float ota_image_selection_changed_at { get; set; }
        public float ota_window_start_changed_at { get; set; }
        public float ota_window_end_changed_at { get; set; }
        public float ota_enabled_changed_at { get; set; }
        public float enabled_http_modules_changed_at { get; set; }
        public float updating_firmware_changed_at { get; set; }
        public float firmware_version_changed_at { get; set; }
        public float update_needed_changed_at { get; set; }
        public float mac_address_changed_at { get; set; }
        public float zigbee_mac_address_changed_at { get; set; }
        public float ip_address_changed_at { get; set; }
        public float hub_version_changed_at { get; set; }
        public float app_version_changed_at { get; set; }
        public float connection_type_changed_at { get; set; }
        public float wifi_credentials_present_changed_at { get; set; }
        public float bundle_id_changed_at { get; set; }
        public float present_devices_changed_at { get; set; }
        public float local_control_public_key_hash_changed_at { get; set; }
        public float local_control_id_changed_at { get; set; }
        public float health_changed_at { get; set; }
        public float desired_pairing_mode_changed_at { get; set; }
        public float desired_pairing_device_type_selector_changed_at { get; set; }
        public float desired_kidde_radio_code_changed_at { get; set; }
        public float desired_pairing_mode_duration_changed_at { get; set; }
        public float desired_ota_image_selection_changed_at { get; set; }
        public float desired_ota_window_start_changed_at { get; set; }
        public float desired_ota_window_end_changed_at { get; set; }
        public float desired_ota_enabled_changed_at { get; set; }
        public float desired_enabled_http_modules_changed_at { get; set; }
        public float desired_led_brightness_changed_at { get; set; }
        public object powered { get; set; }
        public object powered_updated_at { get; set; }
        public float desired_powered_updated_at { get; set; }
        public float desired_powered_changed_at { get; set; }
        public float powered_changed_at { get; set; }
    }

    public sealed class DeviceBlind : BaseDevice
    {
    }

    public sealed class DeviceButton : BaseDevice
    {
        public Last_Reading_Button last_reading { get; set; }
        public string button_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public string gang_id { get; set; }
        public string local_id { get; set; }
        public string radio_type { get; set; }
    }

    public sealed class DeviceDeposits : BaseDevice
    {
    }

    public sealed class DeviceDoorbell : BaseDevice
    {
        public DeviceDoorballLastReading last_reading { get; set; }
        public string door_bell_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
    }

    public class DeviceDoorballLastReading
    {
        public bool motion { get; set; }
        public float motion_updated_at { get; set; }
        public bool button_pressed { get; set; }
        public float button_pressed_updated_at { get; set; }
        public string motion_true { get; set; }
        public float motion_true_updated_at { get; set; }
        public string button_pressed_true { get; set; }
        public float button_pressed_true_updated_at { get; set; }
        public bool connection { get; set; }
        public float connection_updated_at { get; set; }
        public string last_recording_cuepoint_id { get; set; }
        public float last_recording_cuepoint_id_updated_at { get; set; }
        public float motion_changed_at { get; set; }
        public float button_pressed_changed_at { get; set; }
        public float motion_true_changed_at { get; set; }
        public float button_pressed_true_changed_at { get; set; }
        public float connection_changed_at { get; set; }
        public float last_recording_cuepoint_id_changed_at { get; set; }
    }

    public sealed class DeviceEggtray : BaseDevice
    {
        public DeviceEggtrayLastReading last_reading { get; set; }
        public int[] eggs { get; set; }
        public int freshness_period { get; set; }
        public string eggtray_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object[] triggers { get; set; }
        public string mac_address { get; set; }
        public string serial { get; set; }
    }

    public class DeviceEggtrayLastReading
    {
        public bool connection { get; set; }
        public float connection_updated_at { get; set; }
        public float battery { get; set; }
        public float battery_updated_at { get; set; }
        public int inventory { get; set; }
        public float inventory_updated_at { get; set; }
        public int age { get; set; }
        public float age_updated_at { get; set; }
        public int freshness_remaining { get; set; }
        public float freshness_remaining_updated_at { get; set; }
        public object next_trigger_at { get; set; }
        public object next_trigger_at_updated_at { get; set; }
        public float egg_1_timestamp { get; set; }
        public float egg_1_timestamp_updated_at { get; set; }
        public float egg_2_timestamp { get; set; }
        public float egg_2_timestamp_updated_at { get; set; }
        public float egg_3_timestamp { get; set; }
        public float egg_3_timestamp_updated_at { get; set; }
        public float egg_4_timestamp { get; set; }
        public float egg_4_timestamp_updated_at { get; set; }
        public float egg_5_timestamp { get; set; }
        public float egg_5_timestamp_updated_at { get; set; }
        public float egg_6_timestamp { get; set; }
        public float egg_6_timestamp_updated_at { get; set; }
        public float egg_7_timestamp { get; set; }
        public float egg_7_timestamp_updated_at { get; set; }
        public float egg_8_timestamp { get; set; }
        public float egg_8_timestamp_updated_at { get; set; }
        public float egg_9_timestamp { get; set; }
        public float egg_9_timestamp_updated_at { get; set; }
        public float egg_10_timestamp { get; set; }
        public float egg_10_timestamp_updated_at { get; set; }
        public float egg_11_timestamp { get; set; }
        public float egg_11_timestamp_updated_at { get; set; }
        public float egg_12_timestamp { get; set; }
        public float egg_12_timestamp_updated_at { get; set; }
        public float egg_13_timestamp { get; set; }
        public float egg_13_timestamp_updated_at { get; set; }
        public int egg_14_timestamp { get; set; }
        public float egg_14_timestamp_updated_at { get; set; }
        public float connection_changed_at { get; set; }
        public float battery_changed_at { get; set; }
        public float egg_1_timestamp_changed_at { get; set; }
        public float egg_2_timestamp_changed_at { get; set; }
        public float egg_3_timestamp_changed_at { get; set; }
        public float egg_4_timestamp_changed_at { get; set; }
        public float egg_5_timestamp_changed_at { get; set; }
        public float egg_6_timestamp_changed_at { get; set; }
        public float egg_7_timestamp_changed_at { get; set; }
        public float egg_8_timestamp_changed_at { get; set; }
        public float egg_9_timestamp_changed_at { get; set; }
        public float egg_10_timestamp_changed_at { get; set; }
        public float egg_11_timestamp_changed_at { get; set; }
        public float egg_12_timestamp_changed_at { get; set; }
        public float egg_13_timestamp_changed_at { get; set; }
        public float egg_14_timestamp_changed_at { get; set; }
    }
    public sealed class DeviceGarageDoor : BaseDevice
    {
    }

    public sealed class DeviceGang : BaseDevice
    {
        public Last_Reading_Gang last_reading { get; set; }
        public string gang_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object local_id { get; set; }
        public object radio_type { get; set; }
    }

    public sealed class DeviceHub : BaseDevice
    {
        public Last_Reading_BinarySwitch last_reading { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object[] triggers { get; set; }
        public bool update_needed { get; set; }
    }

    public sealed class DeviceLightBulb : BaseDevice
    {
        public DeviceLightBulbLastReading last_reading { get; set; }
        public string light_bulb_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object[] triggers { get; set; }
        public object gang_id { get; set; }
        public string local_id { get; set; }
        public string radio_type { get; set; }
        public int order { get; set; }
    }

    public sealed class DeviceLightBulbLastReading : LastReadingBase
    {
        public bool powered { get; set; }
        public float powered_updated_at { get; set; }
        public int brightness { get; set; }
        public float brightness_updated_at { get; set; }
        public float desired_powered_updated_at { get; set; }
        public float desired_brightness_updated_at { get; set; }
        public float connection_changed_at { get; set; }
        public float powered_changed_at { get; set; }
        public float brightness_changed_at { get; set; }
        public float desired_powered_changed_at { get; set; }
        public float desired_brightness_changed_at { get; set; }
        public string color_model { get; set; }
        public float color_model_updated_at { get; set; }
        public object color { get; set; }
        public object color_updated_at { get; set; }
        public float color_x { get; set; }
        public float color_x_updated_at { get; set; }
        public float color_y { get; set; }
        public float color_y_updated_at { get; set; }
        public float hue { get; set; }
        public float hue_updated_at { get; set; }
        public float saturation { get; set; }
        public float saturation_updated_at { get; set; }
        public int color_temperature { get; set; }
        public float color_temperature_updated_at { get; set; }
        public float desired_color_model_updated_at { get; set; }
        public float desired_color_updated_at { get; set; }
        public float desired_color_x_updated_at { get; set; }
        public float desired_color_y_updated_at { get; set; }
        public float desired_hue_updated_at { get; set; }
        public float desired_saturation_updated_at { get; set; }
        public float desired_color_temperature_updated_at { get; set; }
        public float color_model_changed_at { get; set; }
        public float color_x_changed_at { get; set; }
        public float color_y_changed_at { get; set; }
        public float hue_changed_at { get; set; }
        public float saturation_changed_at { get; set; }
        public float color_temperature_changed_at { get; set; }
        public float desired_color_model_changed_at { get; set; }
        public float desired_color_changed_at { get; set; }
        public float desired_color_x_changed_at { get; set; }
        public float desired_color_y_changed_at { get; set; }
        public float desired_hue_changed_at { get; set; }
        public float desired_saturation_changed_at { get; set; }
        public float desired_color_temperature_changed_at { get; set; }
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
        public string remote_id { get; set; }
        public string name { get; set; }
        public object[] members { get; set; }
        public DeviceRemoteLastReading last_reading { get; set; }
        public object hidden_at { get; set; }
        public string local_id { get; set; }
        public string radio_type { get; set; }

    }

    public class DeviceRemoteLastReading : LastReadingBase
    {
        public object firmware_version { get; set; }
        public object firmware_version_updated_at { get; set; }
        public string firmware_date_code { get; set; }
        public float firmware_date_code_updated_at { get; set; }
        public string group_id { get; set; }
        public float group_id_updated_at { get; set; }
        public bool button_on_pressed { get; set; }
        public float button_on_pressed_updated_at { get; set; }
        public bool button_off_pressed { get; set; }
        public float button_off_pressed_updated_at { get; set; }
        public bool button_up_pressed { get; set; }
        public float button_up_pressed_updated_at { get; set; }
        public bool button_down_pressed { get; set; }
        public float button_down_pressed_updated_at { get; set; }
        public bool ready { get; set; }
        public float ready_updated_at { get; set; }
        public string assignment_mode { get; set; }
        public float assignment_mode_updated_at { get; set; }
        public float desired_assignment_mode_updated_at { get; set; }
        public float connection_changed_at { get; set; }
        public float firmware_date_code_changed_at { get; set; }
        public float group_id_changed_at { get; set; }
        public float button_on_pressed_changed_at { get; set; }
        public float button_off_pressed_changed_at { get; set; }
        public float button_up_pressed_changed_at { get; set; }
        public float button_down_pressed_changed_at { get; set; }
        public float ready_changed_at { get; set; }
        public float assignment_mode_changed_at { get; set; }
        public float desired_assignment_mode_changed_at { get; set; }
        public bool needs_repair { get; set; }
        public float needs_repair_updated_at { get; set; }
        public object remote_pairable { get; set; }
        public object remote_pairable_updated_at { get; set; }
        public float needs_repair_changed_at { get; set; }
    }

    public sealed class DeviceSensor : BaseDevice
    {
        public DeviceSensorLastEvent last_event { get; set; }
        public DeviceSensorSensorLastReading last_reading { get; set; }
        public string sensor_pod_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object[] triggers { get; set; }
        public string gang_id { get; set; }
        public string local_id { get; set; }
        public string radio_type { get; set; }
    }

    public sealed class DeviceSensorLastEvent : LastReadingBase
    {
        public object brightness_occurred_at { get; set; }
        public object loudness_occurred_at { get; set; }
        public object vibration_occurred_at { get; set; }
    }

    public class DeviceSensorSensorLastReading
    {
        public float temperature { get; set; }
        public float temperature_updated_at { get; set; }
        public float humidity { get; set; }
        public float humidity_updated_at { get; set; }
        public object presence { get; set; }
        public object presence_updated_at { get; set; }
        public object proximity { get; set; }
        public object proximity_updated_at { get; set; }
        public bool connection { get; set; }
        public float connection_updated_at { get; set; }
        public object agent_session_id { get; set; }
        public object agent_session_id_updated_at { get; set; }
        public float temperature_changed_at { get; set; }
        public float humidity_changed_at { get; set; }
        public float connection_changed_at { get; set; }
        public object opened { get; set; }
        public object opened_updated_at { get; set; }
        public int battery { get; set; }
        public float battery_updated_at { get; set; }
    }

    public sealed class DeviceSiren : BaseDevice
    {
    }

    public class Rootobject
    {
        public string object_type { get; set; }
        public string object_id { get; set; }
        public string uuid { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }
        public object icon_id { get; set; }
        public object icon_code { get; set; }
        public Desired_State desired_state { get; set; }
        public Last_Reading last_reading { get; set; }
        public Subscription subscription { get; set; }
        public string siren_id { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public Units units { get; set; }
        public object hidden_at { get; set; }
        public Capabilities capabilities { get; set; }
        public string device_manufacturer { get; set; }
        public string model_name { get; set; }
        public string upc_id { get; set; }
        public string upc_code { get; set; }
        public string primary_upc_code { get; set; }
        public string hub_id { get; set; }
        public string local_id { get; set; }
        public string radio_type { get; set; }
        public object[] lat_lng { get; set; }
        public string location { get; set; }
    }

    public class Last_Reading
    {
        public bool connection { get; set; }
        public float connection_updated_at { get; set; }
        public bool powered { get; set; }
        public float powered_updated_at { get; set; }
        public float battery { get; set; }
        public float battery_updated_at { get; set; }
        public string siren_volume { get; set; }
        public float siren_volume_updated_at { get; set; }
        public int auto_shutoff { get; set; }
        public float auto_shutoff_updated_at { get; set; }
        public int chime_cycles { get; set; }
        public float chime_cycles_updated_at { get; set; }
        public string chime_volume { get; set; }
        public float chime_volume_updated_at { get; set; }
        public bool strobe_enabled { get; set; }
        public float strobe_enabled_updated_at { get; set; }
        public bool chime_strobe_enabled { get; set; }
        public float chime_strobe_enabled_updated_at { get; set; }
        public string siren_sound { get; set; }
        public float siren_sound_updated_at { get; set; }
        public string activate_chime { get; set; }
        public float activate_chime_updated_at { get; set; }
        public object pending_action { get; set; }
        public object pending_action_updated_at { get; set; }
        public object desired_powered { get; set; }
        public object desired_powered_updated_at { get; set; }
        public object desired_siren_volume { get; set; }
        public object desired_siren_volume_updated_at { get; set; }
        public object desired_auto_shutoff { get; set; }
        public object desired_auto_shutoff_updated_at { get; set; }
        public object desired_chime_cycles { get; set; }
        public object desired_chime_cycles_updated_at { get; set; }
        public object desired_chime_volume { get; set; }
        public object desired_chime_volume_updated_at { get; set; }
        public object desired_strobe_enabled { get; set; }
        public object desired_strobe_enabled_updated_at { get; set; }
        public object desired_chime_strobe_enabled { get; set; }
        public object desired_chime_strobe_enabled_updated_at { get; set; }
        public object desired_siren_sound { get; set; }
        public object desired_siren_sound_updated_at { get; set; }
        public object desired_activate_chime { get; set; }
        public object desired_activate_chime_updated_at { get; set; }
        public object desired_pending_action { get; set; }
        public object desired_pending_action_updated_at { get; set; }
        public float connection_changed_at { get; set; }
        public float powered_changed_at { get; set; }
        public float battery_changed_at { get; set; }
        public float siren_volume_changed_at { get; set; }
        public float auto_shutoff_changed_at { get; set; }
        public float chime_cycles_changed_at { get; set; }
        public float chime_volume_changed_at { get; set; }
        public float strobe_enabled_changed_at { get; set; }
        public float chime_strobe_enabled_changed_at { get; set; }
        public float siren_sound_changed_at { get; set; }
        public float activate_chime_changed_at { get; set; }
    }

    public sealed class DeviceSmokeAlarm : BaseDevice
    {
    }

    public sealed class DeviceSprinkler : BaseDevice
    {
    }

    public sealed class DeviceThermostat : BaseDevice
    {
        public DeviceThermostatLastReading last_reading { get; set; }
        public string thermostat_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object[] triggers { get; set; }
        public object local_id { get; set; }
        public object radio_type { get; set; }
        public string short_name { get; set; }
        public bool smart_schedule_enabled { get; set; }
    }

    public class DeviceThermostatLastReading : LastReadingBase
    {
        public float max_set_point { get; set; }
        public float max_set_point_updated_at { get; set; }
        public float min_set_point { get; set; }
        public float min_set_point_updated_at { get; set; }
        public float eco_max_set_point { get; set; }
        public float eco_max_set_point_updated_at { get; set; }
        public float eco_min_set_point { get; set; }
        public float eco_min_set_point_updated_at { get; set; }
        public bool powered { get; set; }
        public float powered_updated_at { get; set; }
        public bool users_away { get; set; }
        public float users_away_updated_at { get; set; }
        public bool fan_timer_active { get; set; }
        public float fan_timer_active_updated_at { get; set; }
        public DeviceThermostatUnits units { get; set; }
        public float units_updated_at { get; set; }
        public int temperature { get; set; }
        public float temperature_updated_at { get; set; }
        public object external_temperature { get; set; }
        public object external_temperature_updated_at { get; set; }
        public object min_min_set_point { get; set; }
        public object min_min_set_point_updated_at { get; set; }
        public object max_min_set_point { get; set; }
        public object max_min_set_point_updated_at { get; set; }
        public object min_max_set_point { get; set; }
        public object min_max_set_point_updated_at { get; set; }
        public object max_max_set_point { get; set; }
        public object max_max_set_point_updated_at { get; set; }
        public float deadband { get; set; }
        public float deadband_updated_at { get; set; }
        public bool eco_target { get; set; }
        public float eco_target_updated_at { get; set; }
        public string manufacturer_structure_id { get; set; }
        public float manufacturer_structure_id_updated_at { get; set; }
        public bool has_fan { get; set; }
        public float has_fan_updated_at { get; set; }
        public int fan_duration { get; set; }
        public float fan_duration_updated_at { get; set; }
        public string last_error { get; set; }
        public float last_error_updated_at { get; set; }
        public string mode { get; set; }
        public float mode_updated_at { get; set; }
        public string short_name { get; set; }
        public float short_name_updated_at { get; set; }
        public string[] modes_allowed { get; set; }
        public float modes_allowed_updated_at { get; set; }
        public float desired_max_set_point_updated_at { get; set; }
        public float desired_min_set_point_updated_at { get; set; }
        public float desired_eco_max_set_point_updated_at { get; set; }
        public float desired_eco_min_set_point_updated_at { get; set; }
        public float desired_powered_updated_at { get; set; }
        public float desired_users_away_updated_at { get; set; }
        public float desired_fan_timer_active_updated_at { get; set; }
        public float desired_units_updated_at { get; set; }
        public float desired_mode_updated_at { get; set; }
        public float desired_short_name_updated_at { get; set; }
        public float max_set_point_changed_at { get; set; }
        public float min_set_point_changed_at { get; set; }
        public float eco_max_set_point_changed_at { get; set; }
        public float eco_min_set_point_changed_at { get; set; }
        public float powered_changed_at { get; set; }
        public float users_away_changed_at { get; set; }
        public float fan_timer_active_changed_at { get; set; }
        public float units_changed_at { get; set; }
        public float temperature_changed_at { get; set; }
        public float deadband_changed_at { get; set; }
        public float eco_target_changed_at { get; set; }
        public float manufacturer_structure_id_changed_at { get; set; }
        public float has_fan_changed_at { get; set; }
        public float fan_duration_changed_at { get; set; }
        public float last_error_changed_at { get; set; }
        public float connection_changed_at { get; set; }
        public float mode_changed_at { get; set; }
        public float short_name_changed_at { get; set; }
        public float modes_allowed_changed_at { get; set; }
        public float desired_max_set_point_changed_at { get; set; }
        public float desired_min_set_point_changed_at { get; set; }
        public float desired_eco_max_set_point_changed_at { get; set; }
        public float desired_eco_min_set_point_changed_at { get; set; }
        public float desired_powered_changed_at { get; set; }
        public float desired_users_away_changed_at { get; set; }
        public float desired_fan_timer_active_changed_at { get; set; }
        public float desired_units_changed_at { get; set; }
        public float desired_mode_changed_at { get; set; }
        public float desired_short_name_changed_at { get; set; }
        public float min_min_set_point_changed_at { get; set; }
        public float max_min_set_point_changed_at { get; set; }
        public float min_max_set_point_changed_at { get; set; }
        public float max_max_set_point_changed_at { get; set; }
    }

    public class DeviceThermostatUnits
    {
        public string temperature { get; set; }
    }


    public sealed class DeviceUnknown : BaseDevice
    {
        public DeviceUnknownLastReading last_reading { get; set; }
        public string unknown_device_id { get; set; }
        public string name { get; set; }
        public object hidden_at { get; set; }
        public object[] triggers { get; set; }
        public string local_id { get; set; }
        public string radio_type { get; set; }
    }

    public class DeviceUnknownLastReading : LastReadingBase
    {
        public bool powered { get; set; }
        public float powered_updated_at { get; set; }
        public object desired_powered { get; set; }
        public object desired_powered_updated_at { get; set; }
        public float connection_changed_at { get; set; }
        public float powered_changed_at { get; set; }
    }

    public sealed class DeviceWaterHeater : BaseDevice
    {
    }
}
