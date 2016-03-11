namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppInterop.Database;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;

    public partial class RenamePage : PhoneApplicationPage
    {
        private ROMDatabase db;
        private ROMDBEntry entry;

        public RenamePage()
        {
            object obj2;
            this.InitializeComponent();
            PhoneApplicationService.Current.State.TryGetValue("parameter", out obj2);
            PhoneApplicationService.Current.State.Remove("parameter");
            this.entry = obj2 as ROMDBEntry;
            PhoneApplicationService.Current.State.TryGetValue("parameter2", out obj2);
            PhoneApplicationService.Current.State.Remove("parameter2");
            this.db = obj2 as ROMDatabase;
            this.nameBox.Text = (this.entry.DisplayName);
            SystemTray.GetProgressIndicator(this).Text = (AppResources.ApplicationTitle2);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            base.NavigationService.GoBack();
        }


        private async void renameButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.nameBox.Text))
            {
                if (!this.nameBox.Text.ToLower().Equals(this.entry.DisplayName.ToLower()))
                {
                    if (this.db.IsDisplayNameUnique(this.nameBox.Text))
                    {
                        this.entry.DisplayName = this.nameBox.Text;
                        this.db.CommitChanges();
                        MainPage.shouldRefreshAllROMList = true;
                        //FileHandler.UpdateROMTile(this.entry.FileName);
                        this.NavigationService.GoBack();
                    }
                    else
                    {
                        MessageBox.Show(AppResources.RenameNameAlreadyExisting, AppResources.ErrorCaption, 0);
                    }
                }
            }
            else
            {
                MessageBox.Show(AppResources.RenameEmptyString, AppResources.ErrorCaption, 0);
            }
        }

    }
}

