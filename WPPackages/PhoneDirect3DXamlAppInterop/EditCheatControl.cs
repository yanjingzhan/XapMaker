namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    public partial class EditCheatControl : UserControl
    {
        public static bool IsOKClicked;
        public static string PromptText;
        public static string TextToEdit;

        public EditCheatControl()
        {
            this.InitializeComponent();
            IsOKClicked = false;
            if (PromptText != null)
            {
                this.TblkPromptText.Text = (PromptText);
            }
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.ClosePopup();
        }

        private void ClosePopup()
        {
            (base.Parent as Popup).IsOpen = (false);
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtCheatCode.Text = (TextToEdit);
            this.txtCheatCode.Focus();
        }

        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            TextToEdit = this.txtCheatCode.Text;
            IsOKClicked = true;
            this.ClosePopup();
        }
    }
}

