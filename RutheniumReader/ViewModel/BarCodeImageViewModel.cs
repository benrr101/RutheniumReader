using System.ComponentModel;
using System.Drawing;
using System.Windows.Input;
using RutheniumReader.Commands;
using ZXing;

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

        private string _imageFilePath;
        public string ImageFilePath
        {
            get { return _imageFilePath; }
            set
            {
                _imageFilePath = value;
                OnPropertyChanged("ImageFilePath");
                ReadBarcode(value);
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

        private void ReadBarcode(string imagePath)
        {
            // Load the image that was provided
            Bitmap bitmap = new Bitmap(Image.FromFile(imagePath));
            ImageLoaded = true;

            // Read the barcode from the image
            IBarcodeReader reader = new BarcodeReader();
            Result barcodeResult = reader.Decode(bitmap);

            // Attempt to retrieve the info from the barcode result
            if (barcodeResult != null)
            {
                BarcodeType = barcodeResult.BarcodeFormat.ToString();
                BarcodeValue = barcodeResult.Text;
                BarcodeLoaded = true;
            }
            else
            {
                // Couldn't find a barcode in the image. 
                // TODO: Show an error message
            }
        }
    }
}
