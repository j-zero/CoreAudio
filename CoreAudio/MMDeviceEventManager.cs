using System;
using System.Runtime.InteropServices;
using System.Threading;
using CoreAudio.Interfaces;

namespace CoreAudio
{
    public class MMDeviceEventManager : IMMNotificationClient, IDisposable
    {
        internal static class HResult
        {
            public static readonly int OK = 0;
            public static readonly int NotFound = unchecked((int)0x80070490);
            public static readonly int FileNotFound = unchecked((int)0x80070002);
        }

        private readonly IMMDeviceEnumerator _deviceEnumerator = (IMMDeviceEnumerator)new _MMDeviceEnumerator();

        private readonly SynchronizationContext _synchronizationContext;

        public MMDeviceEventManager()
        {
            _synchronizationContext = SynchronizationContext.Current;

            int hr = _deviceEnumerator.RegisterEndpointNotificationCallback(this);
            if (hr != HResult.OK)
                throw Marshal.GetExceptionForHR(hr);
        }

        public event EventHandler<MMDeviceEventArgs> DeviceAdded;
        public event EventHandler<MMDeviceRemovedEventArgs> DeviceRemoved;
        public event EventHandler<MMDeviceEventArgs> DevicePropertyChanged;
        public event EventHandler<MMDeviceEventArgs> DefaultDeviceChanged;
        public event EventHandler<MMDeviceStateEventArgs> DeviceStateChanged;


        public void Dispose()
        {
            int hr = _deviceEnumerator.UnregisterEndpointNotificationCallback(this);
            if (hr != HResult.OK)
                throw Marshal.GetExceptionForHR(hr);
        }

        public MMDevice GetDevice(string id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            IMMDevice underlyingDevice;
            int hr = _deviceEnumerator.GetDevice(id, out underlyingDevice);
            if (hr == HResult.OK)
                return new MMDevice(underlyingDevice);

            if (hr == HResult.NotFound)
                return null;

            throw Marshal.GetExceptionForHR(hr);
        }

        public void OnDefaultDeviceChanged(EDataFlow flow, ERole role, [In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId)
        {
            InvokeOnSynchronizationContext(() =>
            {
                var handler = DefaultDeviceChanged;
                if (handler != null)
                {
                    MMDevice device = null;
                    if (pwstrDeviceId != null)
                        device = GetDevice(pwstrDeviceId);

                    handler(this, new DefaultAudioDeviceEventArgs(device, flow, role));
                }
            });
        }

        public void OnDeviceAdded([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId)
        {
            InvokeOnSynchronizationContext(() =>
            {
                var handler = DeviceAdded;
                if (handler != null)
                {
                    MMDevice device = GetDevice(pwstrDeviceId);
                    if (device == null)
                        return;     // Device was already removed by the time we got here

                    handler(this, new MMDeviceEventArgs(device));
                }
            });
        }

        public void OnDeviceRemoved([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId)
        {
            InvokeOnSynchronizationContext(() =>
            {
                var handler = DeviceRemoved;
                if (handler != null)
                {
                    handler(this, new MMDeviceRemovedEventArgs(pwstrDeviceId));
                }
            });
        }

        public void OnDeviceStateChanged([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, DEVICE_STATE dwNewState)
        {
            InvokeOnSynchronizationContext(() =>
            {
                var handler = DeviceStateChanged;
                if (handler != null)
                {
                    MMDevice device = GetDevice(pwstrDeviceId);
                    if (device == null)
                        return;     // Device was already removed by the time we got here

                    handler(this, new MMDeviceStateEventArgs(device, dwNewState));
                }
            });
        }

        public void OnPropertyValueChanged([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, PROPERTYKEY key)
        {
            InvokeOnSynchronizationContext(() =>
            {
                var handler = DevicePropertyChanged;
                if (handler != null)
                {
                    MMDevice device = GetDevice(pwstrDeviceId);
                    if (device == null)
                        return;     // Device was already removed by the time I got here

                    handler(this, new MMDeviceEventArgs(device));
                }
            });
        }

        private void InvokeOnSynchronizationContext(Action action)
        {
            if (_synchronizationContext == null)
            {
                action();
            }
            else
            {
                _synchronizationContext.Post(state => { action(); }, null);
            }
        }


    }
}
