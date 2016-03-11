namespace PhoneDirect3DXamlAppInterop
{
    using PhoneDirect3DXamlAppComponent;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.Storage;
    using Windows.Storage.Streams;

    internal partial class GBAIniParser
    {
        public async Task<IDictionary<string, ROMConfig>> ParseAsync(StorageFile file)
        {
            IDictionary<string, ROMConfig> dictionary;
            IDictionary<string, ROMConfig> dict = new Dictionary<string, ROMConfig>();
            string text = null;
            using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
            {
                using (DataReader reader = new DataReader(stream))
                {
                    uint bytesLoaded = await (IAsyncOperation<uint>) reader.LoadAsync((uint) stream.Size);
                    text = reader.ReadString(bytesLoaded);
                }
            }
            if (text == null)
            {
                dictionary = dict;
            }
            else
            {
                string[] lines = text.Split(new char[] { '\n' });
                for (int j = 0; j < lines.Length; j++)
                {
                    string str = lines[j];
                    int index = str.IndexOf('[');
                    if (index != -1)
                    {
                        int num3 = str.IndexOf(']');
                        if (num3 != -1)
                        {
                            ROMConfig config = new ROMConfig {
                                flashSize = -1,
                                mirroringEnabled = -1,
                                rtcEnabled = -1,
                                saveType = -1
                            };
                            string key = str.Substring(index + 1, (num3 - index) - 1);
                            j++;
                            while ((j < lines.Length) && !string.IsNullOrWhiteSpace(lines[j]))
                            {
                                int num5;
                                str = lines[j];
                                int length = str.IndexOf('=');
                                if ((length != -1) && ((length + 1) < str.Length))
                                {
                                    string str5;
                                    string str3 = str.Substring(0, length);
                                    string s = str.Substring(length + 1);
                                    num5 = -1;
                                    if (int.TryParse(s, out num5) && ((str5 = str3) != null))
                                    {
                                        if (!(str5 == "rtcEnabled"))
                                        {
                                            if (str5 == "flashSize")
                                            {
                                                goto Label_02E4;
                                            }
                                            if (str5 == "saveType")
                                            {
                                                goto Label_02EF;
                                            }
                                            if (str5 == "mirroringEnabled")
                                            {
                                                goto Label_02FA;
                                            }
                                        }
                                        else
                                        {
                                            config.rtcEnabled = num5;
                                        }
                                    }
                                }
                                goto Label_0303;
                            Label_02E4:
                                config.flashSize = num5;
                                goto Label_0303;
                            Label_02EF:
                                config.saveType = num5;
                                goto Label_0303;
                            Label_02FA:
                                config.mirroringEnabled = num5;
                            Label_0303:
                                j++;
                            }
                            dict.Add(key, config);
                        }
                    }
                }
                dictionary = dict;
            }
            return dictionary;
        }

    }
}

