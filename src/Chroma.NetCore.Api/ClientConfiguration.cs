using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chroma.NetCore.Api
{
    public class ClientConfiguration : INotifyPropertyChanged
    {
        private Uri exposedBaseAddress;

        public Uri BaseAddress { get; set; }
        public Uri ExposedBaseAddress
        {
            get => exposedBaseAddress;
            set
            {
                exposedBaseAddress = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
