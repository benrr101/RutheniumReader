using System.ComponentModel;
using System.Windows.Input;
using RutheniumReader.Commands;

namespace RutheniumReader.ViewModel
{
    internal class BarCodeImageViewModel : INotifyPropertyChanged
    {

        public BarCodeImageViewModel()
        {
            // Initialize the commands to use
            LoadImageFileCommand = new LoadImageFileCommand(this);
        }

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

        private string _barcodeType;

        public string BarcodeType
        {
            get { return _barcodeType; }
            set
            {
                _barcodeType = value;
                OnPropertyChanged("BarcodeType");
            }
        }

        private string _barcodeValue;

        public string BarcodeValue
        {
            get { return _barcodeValue; }
            set
            {
                _barcodeValue = value;
                OnPropertyChanged("BarcodeValue");
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

        #region Commands

        public ICommand LoadImageFileCommand { get; private set; }

        #endregion
    }
}
