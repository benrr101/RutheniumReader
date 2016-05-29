using System.ComponentModel;

namespace RutheniumReader.ViewModel
{
    internal class BarCodeImageViewModel : INotifyPropertyChanged
    {

        #region UI-Bound Properties

        private bool _barcodeLoaded;

        public bool BarcodeLoaded
        {
            get { return _barcodeLoaded; }
            set
            {
                _barcodeLoaded = value;
                OnPropertyChanged("BarcodeLoaded");
            }
        }

        private bool _imageLoaded;

        public bool ImageLoaded
        {
            get { return _imageLoaded; }
            set
            {
                _imageLoaded = value;
                OnPropertyChanged("ImageLoaded");
            }
        }

        #endregion

        #region IPropertyChanged Interface Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
