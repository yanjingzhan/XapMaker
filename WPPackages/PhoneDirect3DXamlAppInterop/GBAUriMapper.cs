namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.IO;
    using System.Windows.Navigation;
    using Windows.Phone.Storage.SharedAccess;

    internal partial class GBAUriMapper : UriMapperBase
    {
        private string tempUri;

        public override Uri MapUri(Uri uri)
        {
            this.tempUri = uri.ToString();
            if (!this.tempUri.Contains("/FileTypeAssociation"))
            {
                return uri;
            }
            int startIndex = this.tempUri.IndexOf("fileToken=") + 10;
            string fileId = this.tempUri.Substring(startIndex);
            string str3 = Path.GetExtension(SharedStorageAccessManager.GetSharedFileName(fileId)).ToLower();

            if (((!(str3 == ".gb") && !(str3 == ".gbc")) && (!(str3 == ".gba") && !(str3 == ".sav"))) && ((!(str3 == ".sgm") && !(str3 == ".zip")) && ((!(str3 == ".zib") && !(str3 == ".rar")) && !(str3 == ".7z"))))
            {
                return new Uri("/MainPage.xaml", UriKind.Relative);
            }
            return new Uri("/MainPage.xaml?fileToken=" + fileId, UriKind.Relative);
        }
    }
}

