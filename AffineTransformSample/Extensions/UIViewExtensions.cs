using UIKit;

namespace AffineTransformSample.Extensions
{
    public static class UIViewExtensions
    {
        public static UIView FindFirstResponder(this UIView view)
        {
            if (view.IsFirstResponder)
            {
                return view;
            }
            foreach (var subView in view.Subviews)
            {
                var firstResponder = subView.FindFirstResponder();
                if (firstResponder != null)
                {
                    return firstResponder;
                }
            }
            return null;
        }

        public static void HideKeyBoardWhenTappingAnywhere(this UIView view)
        {
            var gesture = new UITapGestureRecognizer(() =>
            {
                var activeView = view.FindFirstResponder();
                if (activeView is UITextField textField)
                {
                    textField.ResignFirstResponder();
                }
                if (activeView is UITextView textView)
                {
                    textView.ResignFirstResponder();
                }
            });
            view.AddGestureRecognizer(gesture);
        }
    }
}

