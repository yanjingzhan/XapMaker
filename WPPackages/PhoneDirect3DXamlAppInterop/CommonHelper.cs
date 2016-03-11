using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;
using PhoneDirect3DXamlAppInterop.Framework;

namespace PhoneDirect3DXamlAppInterop.Helper
{
    internal class CommonHelper
    {

        public static PageOrientation CurrentPageOrientation = PageOrientation.LandscapeRight;

        public static Point GetLandscapeTouchPoint(Point point)
        {
            if (CurrentPageOrientation == PageOrientation.LandscapeRight)
            {
                double x = 800 - point.Y;
                double y = point.X;
                return new Point(x, y);
            }
            else if (CurrentPageOrientation == PageOrientation.LandscapeLeft)
            {
                double y = 480 - point.X;
                double x = point.Y;
                return new Point(x, y);
            }
            else
            {
                return point;
            }

        }

        public static double GetLandscapeXAccelerometerValue(double value)
        {
            if (CurrentPageOrientation == PageOrientation.LandscapeRight)
            {
                return Math.Abs(value);
            }
            else if (CurrentPageOrientation == PageOrientation.LandscapeLeft)
            {
                return -Math.Abs(value);
            }
            else
            {
                return value;
            }
        }

        public static bool  GetLandscapeYAccelerometerValue(double value)
        {
            if (CurrentPageOrientation == PageOrientation.LandscapeRight&&value<0)
            {
                return false;
            }
            if (CurrentPageOrientation == PageOrientation.LandscapeRight && value >=0)
            {
                return true;
            }
            else if (CurrentPageOrientation == PageOrientation.LandscapeLeft&&value<0)
            {
                return true;
            }
            else if (CurrentPageOrientation == PageOrientation.LandscapeLeft && value >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Rect GetSpriteRect(GEGridSprite sprite)
        {
            Rect rect = new Rect(Canvas.GetLeft(sprite), Canvas.GetTop(sprite), sprite.ActualWidth, sprite.ActualHeight);
            return rect;
        }

        public static Point GetSpriteCenterPoint(GEGridSprite sprite)
        {
            Point centerPoint = new Point(Canvas.GetLeft(sprite) + sprite.ActualWidth / 2, Canvas.GetTop(sprite) + sprite.ActualHeight / 2);
            return centerPoint;
        }

        public static void SetSpriteToRectBottom(GEGridSprite sprite, Rect rect)
        {
            Canvas.SetLeft(sprite, rect.X);
            Canvas.SetTop(sprite, rect.Y + rect.Height - sprite.ActualHeight);
        }

        public static void SetSpriteCenterToPoint(GEGridSprite sprite, Point rectCenterPoint)
        {
            Canvas.SetLeft(sprite, rectCenterPoint.X - sprite.ActualWidth / 2);
            Canvas.SetTop(sprite, rectCenterPoint.Y - sprite.ActualHeight / 2);
        }

        public static void SetSpriteCenterToRectCenter(GEGridSprite sprite, Rect rect)
        {
            Point rectCenterPoint = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            Canvas.SetLeft(sprite, rectCenterPoint.X - sprite.ActualWidth / 2);
            Canvas.SetTop(sprite, rectCenterPoint.Y - sprite.ActualHeight / 2);
        }

        public static Image GetImage(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            Image image = new Image();
            image.Source = bitmapImage;
            return image;
        }


        public static void SetToCenterRect(Rect rect, GESprite sprite)
        {
            Canvas.SetLeft(sprite, rect.X + rect.Width / 2 - sprite.SpritImage.ActualWidth / 2);
            Canvas.SetTop(sprite, rect.Y + rect.Height / 2 - sprite.SpritImage.ActualHeight / 2);
        }

        public static void SetToCenterRect(Rect rect, GEGridSprite sprite)
        {
            Canvas.SetLeft(sprite, rect.X + rect.Width / 2 - sprite.SpritImage.ActualWidth / 2);
            Canvas.SetTop(sprite, rect.Y + rect.Height / 2 - sprite.SpritImage.ActualHeight / 2);
        }

        public static void SetToCenterRect(Rect rect, GEGridSprite sprite, double spriteWidth, double spriteHight)
        {
            Canvas.SetLeft(sprite, rect.X + rect.Width / 2 - spriteWidth / 2);
            Canvas.SetTop(sprite, rect.Y + rect.Height / 2 - spriteHight / 2);
        }

        public static Image GetImageFromPath(string path)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(ContentManage.ContenRoot + path, UriKind.RelativeOrAbsolute));
            return new Image() { Source = bitmapImage };
        }

        public static bool IsPointInRect(Rect rect, Point point)
        {
            if ((point.X > rect.X && point.X < (rect.X + rect.Width)) && (point.Y > rect.Y && point.Y < (rect.Y + rect.Height)))
            {
                return true;
            }
            return false;
        }

        public static bool IsClockwise(Point point1, Point point2, Point point3)
        {
            try
            {
                var p12 = new Point(point2.X - point1.X, point2.Y - point1.Y);
                var p23 = new Point(point3.X - point2.X, point3.Y - point2.Y);
                double result = p12.X * p23.Y - p12.Y * p23.X;
                return !(result >= 0);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return false;
        }

        public static bool IsInCircle(double pointx, double pointy, double circlex, double circley, double r)
        {
            return Math.Sqrt(Math.Pow(pointx - circlex, 2) + Math.Pow(pointy - circley, 2)) <= r;
        }

        public static List<T> GetVisualChildCollection<T>(object parent) where T : UIElement
        {
            List<T> visualCollection = new List<T>();
            GetVisualChildCollection(parent as DependencyObject, visualCollection);
            return visualCollection;
        }

        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : UIElement
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }


        public static void ShowToastPrompt(string message)
        {
            var toast = new ToastPrompt();
            toast.Message = message;
            toast.Show();
        }

        public static string Serialize(object objectToSerialize)
        {
            try
            {
                string str;
                using (MemoryStream stream = new MemoryStream())
                {
                    new DataContractJsonSerializer(objectToSerialize.GetType()).WriteObject(stream, objectToSerialize);
                    stream.Position = 0L;
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        str = reader.ReadToEnd();
                        reader.Close();
                    }
                    stream.Close();
                }
                return str;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static T Deserialize<T>(string jsonString)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    return (T)serializer.ReadObject(stream);
                }
            }
            catch (Exception)
            {

                return default(T);
            }
        }

        public static string Decrypt(string input)
        {
            try
            {
                byte[] buffer = Convert.FromBase64String(input);
                byte[] salt = Encoding.UTF8.GetBytes("qwertyuiophoepqpqipi");
                AesManaged managed = new AesManaged();
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes("!@#$%^&*())_", salt);
                managed.BlockSize = managed.LegalBlockSizes[0].MaxSize;
                managed.KeySize = managed.LegalKeySizes[0].MaxSize;
                managed.Key = bytes.GetBytes(managed.KeySize / 8);
                managed.IV = bytes.GetBytes(managed.BlockSize / 8);
                ICryptoTransform transform = managed.CreateDecryptor();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.Close();
                byte[] buffer3 = stream.ToArray();
                return Encoding.UTF8.GetString(buffer3, 0, buffer3.Length);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string Encrypt(string input)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(input);
                byte[] salt = Encoding.UTF8.GetBytes("qwertyuiophoepqpqipi");
                AesManaged managed = new AesManaged();
                Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes("!@#$%^&*())_", salt);
                managed.BlockSize = managed.LegalBlockSizes[0].MaxSize;
                managed.KeySize = managed.LegalKeySizes[0].MaxSize;
                managed.Key = bytes.GetBytes(managed.KeySize / 8);
                managed.IV = bytes.GetBytes(managed.BlockSize / 8);
                ICryptoTransform transform = managed.CreateEncryptor();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.Close();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }



        public static void Navigate(string uri)
        {
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri(uri, UriKind.Relative));
            try
            {

            }
            catch (Exception e)
            {
            }
        }

        public static bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public static T ParseTag<T>(object something)
        {
            return (T)(something as FrameworkElement).Tag;
        }

        //public static WebService1SoapClient GenerateWS(string ws)
        //{
        //    try
        //    {
        //        BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None) { Name = "WebService1Soap", MaxReceivedMessageSize = int.MaxValue, MaxBufferSize = int.MaxValue };
        //        EndpointAddress client = new EndpointAddress(new Uri(ws, UriKind.Absolute));
        //        return new WebService1SoapClient(binding, client);
        //    }
        //    catch (Exception)
        //    {
        //        return null;

        //    }
        //}
    }
}