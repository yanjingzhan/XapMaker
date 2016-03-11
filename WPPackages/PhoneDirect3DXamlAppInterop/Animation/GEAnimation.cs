using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PhoneDirect3DXamlAppInterop.Animation
{
    internal class GEAnimation
    {
        public static DoubleAnimationUsingKeyFrames GEInputObjectScaleX(UIElement targetElement, double duration, double from, double to, double delay = 0)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            try
            {
                EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
                easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0 + delay));
                easingDoubleKeyFrameStart.Value = from;
                easingDoubleKeyFrameStart.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

                EasingDoubleKeyFrame easingDoubleKeyFrame1 = new EasingDoubleKeyFrame();
                easingDoubleKeyFrame1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds((duration + delay) / 2));
                easingDoubleKeyFrame1.Value = 2;
                easingDoubleKeyFrame1.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };
                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrame1);

                EasingDoubleKeyFrame easingDoubleKeyFrame2 = new EasingDoubleKeyFrame();
                easingDoubleKeyFrame2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds((duration + delay) / 2 + (duration + delay) / 4));
                easingDoubleKeyFrame2.Value = 2;
                easingDoubleKeyFrame2.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrame2);

                EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
                easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration + delay));
                easingDoubleKeyFrameEnd.Value = to;
                easingDoubleKeyFrameEnd.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

                Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
                Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.ScaleX)"));
            }
            catch (Exception)
            {

            }

            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GEInputObjectScaleY(UIElement targetElement, double duration, double from, double to, double delay = 0)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();
            try
            {
                EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
                easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0 + delay));
                easingDoubleKeyFrameStart.Value = from;
                easingDoubleKeyFrameStart.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

                EasingDoubleKeyFrame easingDoubleKeyFrame1 = new EasingDoubleKeyFrame();
                easingDoubleKeyFrame1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds((duration + delay) / 2));
                easingDoubleKeyFrame1.Value = 2;
                easingDoubleKeyFrame1.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrame1);

                EasingDoubleKeyFrame easingDoubleKeyFrame2 = new EasingDoubleKeyFrame();
                easingDoubleKeyFrame2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds((duration + delay) / 2 + (duration + delay) / 4));
                easingDoubleKeyFrame2.Value = 2;
                easingDoubleKeyFrame2.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrame2);

                EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
                easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration + delay));
                easingDoubleKeyFrameEnd.Value = to;
                easingDoubleKeyFrameEnd.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

                doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

                Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
                Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.ScaleY)"));
            }
            catch (Exception)
            {

            }
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GERotationYUsingKeyTime(UIElement targetElement, double duration, double from, double to, double delay = 0)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0 + delay));
            easingDoubleKeyFrameStart.Value = from;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration + delay));
            easingDoubleKeyFrameEnd.Value = to;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.Projection).(PlaneProjection.RotationY)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GECenterOfRotationXUsingKeyTime(UIElement targetElement, double duration, double to)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration));
            easingDoubleKeyFrameStart.Value = to;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.Projection).(PlaneProjection.CenterOfRotationX)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GECanvasTopUsingKeyTime(UIElement targetElement, double duration, double from, double to,double delay=0)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0+delay));
            easingDoubleKeyFrameStart.Value = from;
            easingDoubleKeyFrameStart.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration+delay));
            easingDoubleKeyFrameEnd.Value = to;
            easingDoubleKeyFrameEnd.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(Canvas.Top)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GECanvasLeftUsingKeyTime(UIElement targetElement, double duration, double from, double to,double delay=0)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0+delay));
            easingDoubleKeyFrameStart.Value = from;
            easingDoubleKeyFrameStart.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration+delay));
            easingDoubleKeyFrameEnd.Value = to;
            easingDoubleKeyFrameEnd.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(Canvas.Left)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GERotationUsingKeyTime(UIElement targetElement, double duration, double from, double to,double delay=0)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0+delay));
            easingDoubleKeyFrameStart.Value = from;
            easingDoubleKeyFrameStart.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration + delay));
            easingDoubleKeyFrameEnd.Value = to;
            easingDoubleKeyFrameEnd.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };

            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.Rotation)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GEOpacityUsingKeyTime(UIElement targetElement, double duration, double from, double to,double delay=0)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0+delay));
            easingDoubleKeyFrameStart.Value = from;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration+delay));
            easingDoubleKeyFrameEnd.Value = to;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.Opacity)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GETanslateXUsingKeyTime(UIElement targetElement, double duration, double from, double to)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
            easingDoubleKeyFrameStart.Value = from;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration));
            easingDoubleKeyFrameEnd.Value = to;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimationUsingKeyFrames GETanslateYUsingKeyTime(UIElement targetElement, double duration, double from, double to)
        {
            DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
            easingDoubleKeyFrameStart.Value = from;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration));
            easingDoubleKeyFrameEnd.Value = to;
            doubleAnimationUsingKeyFrames.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(doubleAnimationUsingKeyFrames, targetElement);
            Storyboard.SetTargetProperty(doubleAnimationUsingKeyFrames, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateY)"));
            return doubleAnimationUsingKeyFrames;
        }

        public static DoubleAnimation GERotation1(UIElement targetElement, double duration, double to)
        {
            DoubleAnimation rotationAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = to
            };

            RotateTransform rotateTransform = new RotateTransform() { Angle = to, CenterY = 0.0, CenterX = 0.5 };
            targetElement.RenderTransform = rotateTransform;
            
            Storyboard.SetTarget(rotationAnimation, rotateTransform);
            Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath(RotateTransform.AngleProperty));
            return rotationAnimation;
        }

        public static DoubleAnimation GERotation(UIElement targetElement, double duration, double to)
        {
            DoubleAnimation rotationAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = to
            };

            Storyboard.SetTarget(rotationAnimation, targetElement);
            Storyboard.SetTargetProperty(rotationAnimation, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.Rotation)", new object[0]));
            return rotationAnimation;
        }

        public static DoubleAnimation GETranslateX(UIElement targetElement, double duration, double to)
        {
            DoubleAnimation translateXAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = to
            };

            Storyboard.SetTarget(translateXAnimation, targetElement);
            Storyboard.SetTargetProperty(translateXAnimation, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateX)", new object[0]));
            return translateXAnimation;
        }

        public static DoubleAnimation GETranslateY(UIElement targetElement, double duration, double to)
        {
            DoubleAnimation translateYAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = to
            };

            Storyboard.SetTarget(translateYAnimation, targetElement);
            Storyboard.SetTargetProperty(translateYAnimation, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.TranslateY)", new object[0]));
            return translateYAnimation;
        }

        public static DoubleAnimationUsingKeyFrames GEScaleX(UIElement targetElement, double duration, double from, double to)
        {
            DoubleAnimationUsingKeyFrames scaleXAnimation = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
            easingDoubleKeyFrameStart.Value = from;
            scaleXAnimation.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration));
            easingDoubleKeyFrameEnd.Value = to;
            scaleXAnimation.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(scaleXAnimation, targetElement);
            Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.ScaleX)", new object[0]));
            return scaleXAnimation;
        }

        public static DoubleAnimation GEScaleWidth(UIElement targetElement, double duration, double to)
        {
            DoubleAnimation scaleWidthAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = to
            };

            Storyboard.SetTarget(scaleWidthAnimation, targetElement);
            Storyboard.SetTargetProperty(scaleWidthAnimation, new PropertyPath("(FrameworkElement.Width)", new object[0]));
            return scaleWidthAnimation;
        }

        public static DoubleAnimation GEScaleHeight(UIElement targetElement, double duration, double to)
        {
            DoubleAnimation scaleHeightAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = to
            };

            Storyboard.SetTarget(scaleHeightAnimation, targetElement);
            Storyboard.SetTargetProperty(scaleHeightAnimation, new PropertyPath("(FrameworkElement.Height)", new object[0]));
            return scaleHeightAnimation;
        }

        public static DoubleAnimationUsingKeyFrames GEScaleY(UIElement targetElement, double duration, double from, double to)
        {
            DoubleAnimationUsingKeyFrames scaleYAnimation = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame easingDoubleKeyFrameStart = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameStart.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
            easingDoubleKeyFrameStart.Value = from;
            scaleYAnimation.KeyFrames.Add(easingDoubleKeyFrameStart);

            EasingDoubleKeyFrame easingDoubleKeyFrameEnd = new EasingDoubleKeyFrame();
            easingDoubleKeyFrameEnd.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(duration));
            easingDoubleKeyFrameEnd.Value = to;
            scaleYAnimation.KeyFrames.Add(easingDoubleKeyFrameEnd);

            Storyboard.SetTarget(scaleYAnimation, targetElement);
            Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.ScaleY)", new object[0]));
            return scaleYAnimation;
        }

        public  static Storyboard RunAnimations(List<Timeline> timelines, Action action = null, bool runNow = true)
        {
            Storyboard storyboard = new Storyboard();
            try
            {
                foreach (var timeline in timelines)
                {
                    storyboard.Children.Add(timeline);
                }
                if (runNow)
                {
                    storyboard.Begin();
                }

                storyboard.Completed += (object sender, EventArgs e) =>
                {
                    if (action != null)
                    {
                        action.Invoke();
                    }
                };
            }
            catch (Exception)
            {

            }
            return storyboard;
        }

    }
}
