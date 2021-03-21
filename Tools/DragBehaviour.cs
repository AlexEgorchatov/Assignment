using System.Windows;
using System.Windows.Interactivity;

namespace Assignment.Tools
{
    public class DragBehaviour : Behavior<UIElement>
    {
        #region Private Fields

        private Point _mouseStartPosition;

        #endregion

        #region Protected Methods

        protected override void OnAttached()
        {
            var parent = Application.Current.MainWindow as MainWindow;

            AssociatedObject.MouseLeftButtonDown += (sender, e) =>
            {
                _mouseStartPosition = e.GetPosition(parent);
                AssociatedObject.CaptureMouse();
            };

            AssociatedObject.MouseMove += (sender, e) =>
            {
                if (AssociatedObject.IsMouseCaptured)
                {
                    double scalingFactor = PresentationSource.FromVisual(parent).CompositionTarget.TransformToDevice.M11;
                    var mouseCurrentRelativePosition = e.GetPosition(parent);
                    var mouseCurrentAbsolutePosition = parent.PointToScreen(mouseCurrentRelativePosition);
                    parent.Left = mouseCurrentAbsolutePosition.X / scalingFactor - _mouseStartPosition.X;
                    parent.Top = mouseCurrentAbsolutePosition.Y / scalingFactor - _mouseStartPosition.Y;
                }
            };

            AssociatedObject.MouseLeftButtonUp += (sender, e) =>
            {
                AssociatedObject.ReleaseMouseCapture();
            };
        }

        #endregion
    }
}