using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PhoneDirect3DXamlAppInterop.Framework;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class FrameSprite : GEGridSprite
    {
        public string framePath;
        public int frameCount = 0;
        public int CurrentFrame = 0;
        public DispatcherTimer timer = new DispatcherTimer();
        public int zeroIndex = 0;
        public bool IsStopInLastFrame = true;
        public Action CompletedAction;
        public int currentLoopTimes = 1;
        public LoopType CurrentLoopType = LoopType.Forever;
        public int FrameLoopTimes = 1;
        public Action OneFrameCompletedAction;

        public FrameSprite(string framePath, int frameCount,int startFrame=0, double interval = 50,int zeroIndex=1)
        {
            this.zeroIndex = zeroIndex;
            CurrentFrame = startFrame;
            this.framePath = framePath;
            this.frameCount = frameCount;
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(interval);

            SpritImage.Source = GetImage(string.Format(framePath,CurrentFrame));
            this.Children.Add(SpritImage);
            Canvas.SetLeft(SpritImage, 0);
            Canvas.SetTop(SpritImage, 0);
        }

        public BitmapImage GetImage(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            CurrentFrame++;
            if (OneFrameCompletedAction != null)
            {
                OneFrameCompletedAction.Invoke();
            }

            if (CurrentLoopType == LoopType.Forever)
            {
                if (CurrentFrame > frameCount)
                {
                    CurrentFrame = zeroIndex;
                    SpritImage.Source = GetImage(string.Format(framePath, CurrentFrame));
                }
                else if (CurrentFrame <= frameCount)
                {
                    SpritImage.Source = GetImage(string.Format(framePath, CurrentFrame));
                }
            }
            else
            {
                if (CurrentFrame > frameCount)
                {
                    currentLoopTimes++;
                    if (currentLoopTimes <= FrameLoopTimes)
                    {
                        CurrentFrame = zeroIndex;
                        SpritImage.Source = GetImage(string.Format(framePath, CurrentFrame));
                    }
                    else
                    {
                        timer.Stop();
                        if (!IsStopInLastFrame)
                        {
                            CurrentFrame = zeroIndex;
                            SpritImage.Source = GetImage(string.Format(framePath, CurrentFrame));
                        }
                        if (CompletedAction != null)
                        {
                            CompletedAction.Invoke();
                        }
                    }

                }
                else if (CurrentFrame <= frameCount)
                {
                    SpritImage.Source = GetImage(string.Format(framePath, CurrentFrame));
                }
            }
        }

        public void SetFrameImage(int frame)
        {
            CurrentFrame = frame;
            SpritImage.Source = GetImage(string.Format(framePath, CurrentFrame));
        }

        public void StopFrame()
        {
            timer.Stop();
        }

        public void StartFrame()
        {
            timer.Start();
            this.Opacity = 1;
        }

        public enum LoopType
        {
            LoopByTime,
            Forever
        }
    }
}
