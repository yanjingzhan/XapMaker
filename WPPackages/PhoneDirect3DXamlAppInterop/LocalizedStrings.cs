namespace PhoneDirect3DXamlAppInterop
{
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;

    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources
        {
            get
            {
                return _localizedResources;
            }
        }
    }
}

