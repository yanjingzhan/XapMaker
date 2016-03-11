namespace CloudSixConnector.FilePicker
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Windows.Phone.Storage.SharedAccess;
    using Windows.Storage;

    public class CloudSixFileSelected
    {
        private string _fileid;

        public CloudSixFileSelected()
        {
        }

        public CloudSixFileSelected(string fileid)
        {
            this._fileid = fileid;
            string[] source = SharedStorageAccessManager.GetSharedFileName(fileid).Split(new char[] { '.' });
            if (source.Length > 2)
            {
                this.Token = source[source.Length - 2];
                this.Filename = source.Take<string>((source.Length - 2)).Aggregate<string>((a, b) => a + "." + b);
            }
        }

        public async Task<IStorageFile> CopySharedFileAsync(string localfilepath)
        {
            return await SharedStorageAccessManager.CopySharedFileAsync(ApplicationData.Current.LocalFolder, localfilepath, (NameCollisionOption)1, this._fileid);
        }

        public string Filename { get; set; }

        public string Token { get; set; }

    }
}

