namespace DucLe.Extensions
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Reflection;
    using System.Text;

    public class QueryString
    {
        private readonly Dictionary<string, string> _parameters;

        public QueryString()
        {
            this._parameters = new Dictionary<string, string>();
        }

        public QueryString(string uri)
            : this()
        {
            this.Append(uri);
        }

        public QueryString(Dictionary<string, string> parameters)
        {
            this._parameters = parameters;
        }

        public QueryString(Uri uri)
            : this(uri.ToString())
        {
        }

        public void Append(string uri)
        {
            string str;
            if (uri.IndexOf('?') > -1)
            {
                str = uri.Substring(uri.IndexOf('?') + 1);
            }
            else
            {
                return;
            }
            foreach (string[] strArray2 in from s in str.Split(new char[] { '&' }) select s.Split(new char[] { '=' }))
            {
                this._parameters.Add(strArray2[0], HttpUtility.UrlDecode(strArray2[1]));
            }
        }

        public bool ContainsKey(string key)
        {
            return this._parameters.ContainsKey(key);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in this._parameters)
            {
                if (builder.Length > 0)
                {
                    builder.Append('&');
                }
                builder.AppendFormat("{0}={1}", new object[] { pair.Key, pair.Value });
            }
            return builder.ToString();
        }

        public string this[string key]
        {
            get
            {
                if (!this._parameters.ContainsKey(key))
                {
                    return null;
                }
                return this._parameters[key];
            }
            set
            {
                if (this._parameters.ContainsKey(key))
                {
                    this._parameters[key] = value;
                }
                else
                {
                    this._parameters.Add(key, value);
                }
            }
        }
    }
}

