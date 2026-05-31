using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MBColumn.Application.Services;

namespace MBColumn.Presentation.Wpf.Views;

public partial class AddSectionDialog : Window
{
    public string SectionName { get; private set; } = "";
    public int? SelectedGroupId { get; private set; }

    public class GroupOption
    {
        public int? Id { get; set; }
        public string Name { get; set; } = "";
    }

    public AddSectionDialog(string defaultName, IEnumerable<GroupRecord> availableGroups, int? defaultGroupId = null)
    {
        InitializeComponent();
        NameBox.Text = defaultName;

        var options = new List<GroupOption>
        {
            new GroupOption { Id = null, Name = "(None)" }
        };

        foreach (var g in availableGroups)
        {
            options.Add(new GroupOption { Id = g.Id, Name = g.Name });
        }

        GroupComboBox.ItemsSource = options;
        
        if (defaultGroupId.HasValue)
        {
            GroupComboBox.SelectedValue = defaultGroupId.Value;
        }
        else
        {
            GroupComboBox.SelectedIndex = 0;
        }

        Loaded += (_, _) =>
        {
            NameBox.Focus();
            NameBox.SelectAll();
        };
    }

    private void OK_Click(object sender, RoutedEventArgs e) => Commit();
    private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;

    private void NameBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) Commit();
    }

    private void Commit()
    {
        var name = NameBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Section name cannot be empty.", "Validation",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        SectionName = name;
        SelectedGroupId = (int?)GroupComboBox.SelectedValue;
        DialogResult = true;
    }
}
