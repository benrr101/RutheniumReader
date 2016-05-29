using System;
using System.Windows.Input;
using RutheniumReader.ViewModel;
using Microsoft.Win32;

namespace RutheniumReader.Commands
{
    internal class LoadImageFileCommand : ICommand
    {
        private BarCodeImageViewModel _viewModel;

        public LoadImageFileCommand(BarCodeImageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Open the file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif|All Files|*.*"
            };

            bool? result = openFileDialog.ShowDialog();

            // If we have a result, then load that file
            if (result == true)
            {
                _viewModel.ImageFilePath = openFileDialog.FileName;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
