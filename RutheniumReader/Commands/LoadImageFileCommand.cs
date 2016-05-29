using System;
using System.Windows.Input;
using RutheniumReader.ViewModel;

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
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
