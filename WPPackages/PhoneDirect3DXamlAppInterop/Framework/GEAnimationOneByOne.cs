using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class GEAnimationOneByOne
    {
        private List<Storyboard> storyboards = new List<Storyboard>();
        private int maxIndex;
        private int currentIndex;
        private DispatcherTimer timer = new DispatcherTimer();
        private bool isForever;
        public Action Completed;
        private bool isRunNow = true;

        public GEAnimationOneByOne(List<Storyboard> storyboards, bool isForever = true,bool isRunNow=true)
        {
            this.storyboards = storyboards;
            maxIndex = storyboards.Count;
            this.isForever = isForever;
            timer.Interval = TimeSpan.FromTicks(333333);
            timer.Tick += timer_Tick;
            this.isRunNow = isRunNow;

            if (this.storyboards != null && this.storyboards.Count > 0)
            {
                if (isRunNow)
                {
                    storyboards[currentIndex].Begin();
                    timer.Start();
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (storyboards.Count > 0)
                {
                    if (storyboards[currentIndex].GetCurrentState() == ClockState.Filling)
                    {
                        if (currentIndex + 1 < maxIndex)
                        {
                            currentIndex += 1;

                            storyboards[currentIndex].Begin();
                        }
                        else
                        {
                            if (isForever)
                            {
                                foreach (var exStoryboard in storyboards)
                                {
                                    exStoryboard.Stop();
                                }
                                currentIndex = 0;
                                storyboards[currentIndex].Begin();
                            }
                            else
                            {
                                timer.Stop();
                                if (Completed != null)
                                {
                                    Completed.Invoke();
                                }
                            }
                        }
                    }
                }
                else
                {
                    timer.Stop();
                    if (Completed != null)
                    {
                        Completed.Invoke();
                    }
                }
            }
            catch (Exception)
            {
                

            }
        }

        public void GEPauseAnimation()
        {
            try
            {
                storyboards[currentIndex].Pause();
                timer.Stop();
            }
            catch (Exception)
            {
                
            }
        }

        public void GEBeginAnimation()
        {
            try
            {
                storyboards[currentIndex].Begin();
                timer.Start();
            }
            catch (Exception)
            {

            }
        }

        public void GEResumeAnimation()
        {
            //if (this.storyboards != null && this.storyboards.Count > 0)
            //{
            //    if (storyboards[currentIndex].GetCurrentState() ==ClockState.)
            //    {
            //        storyboards[currentIndex].Resume();
            //    }
            //    else
            //    {
            //        storyboards[currentIndex].Begin();
            //    }
            //    timer.Start();
            //}
            //else
            //{
            //    timer.Stop();
            //    if (Completed != null)
            //    {
            //        Completed.Invoke();
            //    }
            //}
        }

        public void GERemoveCurrentStoryboard()
        {
            try
            {
                timer.Stop();
                storyboards[currentIndex].Pause();
                storyboards.RemoveAt(currentIndex);
                maxIndex = storyboards.Count;
                if (currentIndex >= maxIndex)
                {
                    currentIndex = 0;
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
