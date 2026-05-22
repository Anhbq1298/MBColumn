using System;
using System.Windows.Input;
using MBColumn.Presentation.Wpf.Commands;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class GroupActionViewModel : ViewModelBase
{
    public string Name { get; }
    public ICommand Command { get; }

    public GroupActionViewModel(string name, Action execute)
    {
        Name = name;
        Command = new RelayCommand(execute);
    }
}
