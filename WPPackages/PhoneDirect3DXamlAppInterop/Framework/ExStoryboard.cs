using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;

namespace PhoneDirect3DXamlAppInterop.Framework
{
    public class ExStoryboard
    {
        private Storyboard storyboard=new Storyboard();

        private string tag=string.Empty;
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        private StoryboardState storyboardState = StoryboardState.Stopped;
        public StoryboardState StoryboardState
        {
            get { return storyboardState; }
            set { storyboardState = value; }
        }

        public void Stop()
        {
            storyboard.Stop();
            StoryboardState = StoryboardState.Stopped;
        }

        public void Begin()
        {
            storyboard.Begin();
            StoryboardState = StoryboardState.Active;
        }

        public void Pause()
        {
            storyboard.Pause();
            StoryboardState = StoryboardState.Pause;
        }

        public void Resume()
        {
            storyboard.Resume();
            StoryboardState = StoryboardState.Active;
        }

        public  ExStoryboard(Storyboard storyboard,string tag)
        {
            this.storyboard = storyboard;
            this.Tag = tag;
            storyboard.Completed += storyboard_Completed;
        }

        void storyboard_Completed(object sender, EventArgs e)
        {
            StoryboardState = StoryboardState.Filling;
        }
    }

    public enum StoryboardState
    {
        Pause,
        Stopped,
        Active,
        Filling
    }
}
