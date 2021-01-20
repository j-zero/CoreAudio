using System;

namespace CoreAudio
{
    public class MMDeviceEventArgs : EventArgs
    {
        private readonly MMDevice _device;
        public MMDeviceEventArgs(MMDevice device)
        {
            _device = device;
        }

        public MMDevice Device
        {
            get { return _device; }
        }
    }
    public class MMDeviceRemovedEventArgs
    {
        private readonly string _deviceId;

        public MMDeviceRemovedEventArgs(string deviceId)
        {
            _deviceId = deviceId;
        }

        public string DeviceId
        {
            get { return _deviceId; }
        }
    }
    public class DefaultAudioDeviceEventArgs : MMDeviceEventArgs
    {
        private readonly EDataFlow _flow;
        private readonly ERole _role;
        public DefaultAudioDeviceEventArgs(MMDevice device, EDataFlow flow, ERole role) : base(device)
        {
            _flow = flow;
            _role = role;
        }

        public EDataFlow Flow
        {
            get { return _flow; }
        }

        public ERole Role
        {
            get { return _role; }
        }
    }
    public class MMDeviceStateEventArgs : MMDeviceEventArgs
    {
        private readonly DEVICE_STATE _newState;

        public MMDeviceStateEventArgs(MMDevice device, DEVICE_STATE newState)
            : base(device)
        {
            _newState = newState;
        }

        public DEVICE_STATE NewState
        {
            get { return _newState; }
        }
    }
}