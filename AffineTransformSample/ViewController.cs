using System;
using AffineTransformSample.Extensions;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;

namespace AffineTransformSample
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.View.BackgroundColor = UIColor.SystemBackground;

            var scrollView = new UIScrollView();
            scrollView.TranslatesAutoresizingMaskIntoConstraints = false;
            this.Add(scrollView);
            var contentView = new UIView();
            contentView.TranslatesAutoresizingMaskIntoConstraints = false;
            scrollView.Add(contentView);

            NSLayoutConstraint.ActivateConstraints(new[] {
                scrollView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor),
                scrollView.LeftAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeftAnchor),
                scrollView.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor),
                scrollView.WidthAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.WidthAnchor),
                contentView.TopAnchor.ConstraintEqualTo(contentView.Superview.TopAnchor),
                contentView.LeftAnchor.ConstraintEqualTo(contentView.Superview.LeftAnchor),
                contentView.RightAnchor.ConstraintEqualTo(contentView.Superview.RightAnchor),
                contentView.BottomAnchor.ConstraintEqualTo(contentView.Superview.BottomAnchor),
            });

            nfloat marginLeft = 10f;
            nfloat marginRight = marginLeft;
            nfloat margin = 20f;

            var labelForTranslateX = new UILabel();
            labelForTranslateX.Text = "x :";
            labelForTranslateX.Font = UIFont.PreferredBody;
            labelForTranslateX.AdjustsFontForContentSizeCategory = true;
            contentView.Add(labelForTranslateX);
            labelForTranslateX.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                labelForTranslateX.TopAnchor.ConstraintEqualTo(labelForTranslateX.Superview.TopAnchor, margin),
                labelForTranslateX.LeftAnchor.ConstraintEqualTo(labelForTranslateX.Superview.LeftAnchor, marginLeft),
            });

            var translateX = new UITextField();
            translateX.Layer.BorderWidth = 1;
            translateX.Layer.BorderColor = UIColor.SystemGray.CGColor;
            translateX.Layer.CornerRadius = 5;
            translateX.Layer.MasksToBounds = true;
            translateX.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
            translateX.Font = UIFont.PreferredBody;
            translateX.AdjustsFontForContentSizeCategory = true;
            contentView.Add(translateX);
            var textSize = (new NSString("100")).GetSizeUsingAttributes(new UIStringAttributes { Font = translateX.Font });
            translateX.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                translateX.CenterYAnchor.ConstraintEqualTo(labelForTranslateX.CenterYAnchor),
                translateX.LeftAnchor.ConstraintEqualTo(labelForTranslateX.RightAnchor, 10),
                translateX.WidthAnchor.ConstraintEqualTo(textSize.Width + 50),
                translateX.HeightAnchor.ConstraintEqualTo(textSize.Height + 10),
            });

            var labelForTranslateY = new UILabel();
            labelForTranslateY.Text = "y :";
            labelForTranslateY.Font = UIFont.PreferredBody;
            labelForTranslateY.AdjustsFontForContentSizeCategory = true;
            contentView.Add(labelForTranslateY);
            labelForTranslateY.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                labelForTranslateY.TopAnchor.ConstraintEqualTo(labelForTranslateX.TopAnchor),
                labelForTranslateY.LeftAnchor.ConstraintEqualTo(translateX.RightAnchor, 10),
            });

            var translateY = new UITextField();
            translateY.Layer.BorderWidth = 1;
            translateY.Layer.BorderColor = UIColor.SystemGray.CGColor;
            translateY.Layer.CornerRadius = 5;
            translateY.Layer.MasksToBounds = true;
            translateY.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
            translateY.Font = UIFont.PreferredBody;
            translateY.AdjustsFontForContentSizeCategory = true;
            contentView.Add(translateY);
            translateY.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                translateY.TopAnchor.ConstraintEqualTo(translateX.TopAnchor),
                translateY.LeftAnchor.ConstraintEqualTo(labelForTranslateY.RightAnchor, 10),
                translateY.WidthAnchor.ConstraintEqualTo(translateX.WidthAnchor),
                translateY.HeightAnchor.ConstraintEqualTo(translateX.HeightAnchor),
            });

            var translateButton = new UIButton();
            translateButton.SetTitle("translate", UIControlState.Normal);
            translateButton.Configuration = UIButtonConfiguration.FilledButtonConfiguration;
            contentView.Add(translateButton);
            translateButton.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                translateButton.CenterYAnchor.ConstraintEqualTo(translateX.CenterYAnchor),
                translateButton.LeftAnchor.ConstraintEqualTo(translateY.RightAnchor, 10),
            });

            UIView lastView = labelForTranslateX;

            var labelForScaleX = new UILabel();
            labelForScaleX.Text = "x :";
            labelForScaleX.Font = UIFont.PreferredBody;
            labelForScaleX.AdjustsFontForContentSizeCategory = true;
            contentView.Add(labelForScaleX);
            labelForScaleX.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                labelForScaleX.TopAnchor.ConstraintEqualTo(lastView.BottomAnchor, margin),
                labelForScaleX.LeftAnchor.ConstraintEqualTo(labelForScaleX.Superview.LeftAnchor, marginLeft),
            });

            var scaleX = new UITextField();
            scaleX.Layer.BorderWidth = 1;
            scaleX.Layer.BorderColor = UIColor.SystemGray.CGColor;
            scaleX.Layer.CornerRadius = 5;
            scaleX.Layer.MasksToBounds = true;
            scaleX.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
            scaleX.Font = UIFont.PreferredBody;
            scaleX.AdjustsFontForContentSizeCategory = true;
            contentView.Add(scaleX);
            textSize = (new NSString("1.0")).GetSizeUsingAttributes(new UIStringAttributes { Font = scaleX.Font });
            scaleX.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                scaleX.CenterYAnchor.ConstraintEqualTo(labelForScaleX.CenterYAnchor),
                scaleX.LeftAnchor.ConstraintEqualTo(labelForScaleX.RightAnchor, 10),
                scaleX.WidthAnchor.ConstraintEqualTo(textSize.Width + 50),
                scaleX.HeightAnchor.ConstraintEqualTo(textSize.Height + 10),
            });

            var labelForScaleY = new UILabel();
            labelForScaleY.Text = "y :";
            labelForScaleY.Font = UIFont.PreferredBody;
            labelForScaleY.AdjustsFontForContentSizeCategory = true;
            contentView.Add(labelForScaleY);
            labelForScaleY.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                labelForScaleY.TopAnchor.ConstraintEqualTo(labelForScaleX.TopAnchor),
                labelForScaleY.LeftAnchor.ConstraintEqualTo(scaleX.RightAnchor, 10),
            });

            var scaleY = new UITextField();
            scaleY.Layer.BorderWidth = 1;
            scaleY.Layer.BorderColor = UIColor.SystemGray.CGColor;
            scaleY.Layer.CornerRadius = 5;
            scaleY.Layer.MasksToBounds = true;
            scaleY.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
            scaleY.Font = UIFont.PreferredBody;
            scaleY.AdjustsFontForContentSizeCategory = true;
            contentView.Add(scaleY);
            scaleY.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                scaleY.TopAnchor.ConstraintEqualTo(scaleX.TopAnchor),
                scaleY.LeftAnchor.ConstraintEqualTo(labelForScaleY.RightAnchor, 10),
                scaleY.WidthAnchor.ConstraintEqualTo(scaleX.WidthAnchor),
                scaleY.HeightAnchor.ConstraintEqualTo(scaleX.HeightAnchor),
            });

            var scaleButton = new UIButton();
            scaleButton.SetTitle("scale", UIControlState.Normal);
            scaleButton.Configuration = UIButtonConfiguration.FilledButtonConfiguration;
            contentView.Add(scaleButton);
            scaleButton.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                scaleButton.CenterYAnchor.ConstraintEqualTo(scaleX.CenterYAnchor),
                scaleButton.LeftAnchor.ConstraintEqualTo(scaleY.RightAnchor, 10),
            });

            lastView = labelForScaleX;

            var labelForRotate = new UILabel();
            labelForRotate.Text = "円周率 x ";
            labelForRotate.Font = UIFont.PreferredBody;
            labelForRotate.AdjustsFontForContentSizeCategory = true;
            contentView.Add(labelForRotate);
            textSize = (new NSString("1.0")).GetSizeUsingAttributes(new UIStringAttributes { Font = scaleX.Font });
            labelForRotate.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                labelForRotate.TopAnchor.ConstraintEqualTo(lastView.BottomAnchor, margin),
                labelForRotate.LeftAnchor.ConstraintEqualTo(labelForRotate.Superview.LeftAnchor, marginLeft),
            });

            var rotate = new UITextField();
            rotate.Layer.BorderWidth = 1;
            rotate.Layer.BorderColor = UIColor.SystemGray.CGColor;
            rotate.Layer.CornerRadius = 5;
            rotate.Layer.MasksToBounds = true;
            rotate.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
            rotate.Font = UIFont.PreferredBody;
            rotate.AdjustsFontForContentSizeCategory = true;
            contentView.Add(rotate);
            rotate.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                rotate.CenterYAnchor.ConstraintEqualTo(labelForRotate.CenterYAnchor),
                rotate.LeftAnchor.ConstraintEqualTo(labelForRotate.RightAnchor, 10),
                rotate.WidthAnchor.ConstraintEqualTo(textSize.Width + 50),
                rotate.HeightAnchor.ConstraintEqualTo(textSize.Height + 10),
            });

            var rotateButton = new UIButton();
            rotateButton.SetTitle("rotate", UIControlState.Normal);
            rotateButton.Configuration = UIButtonConfiguration.FilledButtonConfiguration;
            contentView.Add(rotateButton);
            rotateButton.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                rotateButton.CenterYAnchor.ConstraintEqualTo(rotate.CenterYAnchor),
                rotateButton.LeftAnchor.ConstraintEqualTo(rotate.RightAnchor, 10),
            });

            lastView = labelForRotate;

            var customButton = new UIButton();
            customButton.SetTitle("カスタム変換", UIControlState.Normal);
            customButton.Configuration = UIButtonConfiguration.FilledButtonConfiguration;
            contentView.Add(customButton);
            customButton.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                customButton.TopAnchor.ConstraintEqualTo(lastView.BottomAnchor, margin),
                customButton.LeftAnchor.ConstraintEqualTo(customButton.Superview.LeftAnchor, marginLeft),
            });

            lastView = customButton;

            var pickPhotoButton = new UIButton();
            pickPhotoButton.SetTitle("写真選択", UIControlState.Normal);
            pickPhotoButton.Configuration = UIButtonConfiguration.FilledButtonConfiguration;
            contentView.Add(pickPhotoButton);
            pickPhotoButton.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                pickPhotoButton.TopAnchor.ConstraintEqualTo(lastView.BottomAnchor, margin),
                pickPhotoButton.LeftAnchor.ConstraintEqualTo(labelForTranslateX.Superview.LeftAnchor, marginLeft),
            });

            lastView = pickPhotoButton;

            var imageView = new UIImageView();
            imageView.BackgroundColor = UIColor.SystemGray;
            contentView.Add(imageView);
            imageView.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.ActivateConstraints(new[] {
                imageView.TopAnchor.ConstraintEqualTo(lastView.BottomAnchor, margin),
                imageView.LeftAnchor.ConstraintEqualTo(imageView.Superview.LeftAnchor, marginLeft),
            });

            lastView = imageView;

            pickPhotoButton.ExclusiveTouch = true;
            pickPhotoButton.TouchUpInside += async (sender, e) =>
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    imageView.Image = UIImage.FromFile(photo.FullPath);
                }
            };

            translateButton.ExclusiveTouch = true;
            translateButton.TouchUpInside += (sender, e) =>
            {
                if (imageView.Image == null)
                {
                    return;
                }
                if (!nfloat.TryParse(translateX.Text, out var tx))
                {
                    return;
                }
                if (!nfloat.TryParse(translateY.Text, out var ty))
                {
                    return;
                }
                var transform = CGAffineTransform.MakeIdentity();
                transform = CGAffineTransform.Translate(transform, tx, ty);
                imageView.Image = Convert(imageView.Image, transform);
            };

            scaleButton.ExclusiveTouch = true;
            scaleButton.TouchUpInside += (sender, e) =>
            {
                if (imageView.Image == null)
                {
                    return;
                }
                if (!nfloat.TryParse(scaleX.Text, out var sx))
                {
                    return;
                }
                if (!nfloat.TryParse(scaleY.Text, out var sy))
                {
                    return;
                }
                var transform = CGAffineTransform.MakeIdentity();
                transform = CGAffineTransform.Scale(transform, sx, sy);
                imageView.Image = Convert(imageView.Image, transform);
            };

            rotateButton.ExclusiveTouch = true;
            rotateButton.TouchUpInside += (sender, e) =>
            {
                if (imageView.Image == null)
                {
                    return;
                }
                if (!nfloat.TryParse(rotate.Text, out var angle))
                {
                    return;
                }
                var transform = CGAffineTransform.MakeIdentity();
                transform = CGAffineTransform.Rotate(transform, (nfloat)(Math.PI * angle));
                imageView.Image = Convert(imageView.Image, transform);
            };

            customButton.ExclusiveTouch = true;
            customButton.TouchUpInside += (sender, e) =>
            {
                if (imageView.Image == null)
                {
                    return;
                }
                var imageSize = imageView.Image.Size;
                var transform = CGAffineTransform.MakeIdentity();
                transform = CGAffineTransform.Translate(transform, imageSize.Height, 0);
                transform = CGAffineTransform.Rotate(transform, (nfloat)(Math.PI / 2));
                transform = CGAffineTransform.Translate(transform, imageSize.Width, 0);
                transform = CGAffineTransform.Scale(transform, -1, 1);
                var drawImageSize = new CGSize(imageSize.Height, imageSize.Width);
                imageView.Image = Convert(imageView.Image, transform, drawImageSize);
            };

            NSLayoutConstraint.ActivateConstraints(new[] {
                scrollView.ContentLayoutGuide.BottomAnchor.ConstraintEqualTo(lastView.BottomAnchor, margin),
                scrollView.ContentLayoutGuide.RightAnchor.ConstraintGreaterThanOrEqualTo(scrollView.Superview.RightAnchor),
                scrollView.ContentLayoutGuide.RightAnchor.ConstraintEqualTo(imageView.RightAnchor, marginRight),
            });

            this.View.HideKeyBoardWhenTappingAnywhere();
        }

        UIImage Convert(UIImage image, CGAffineTransform transform, CGSize? drawImageSize = null)
        {
            UIGraphics.BeginImageContext(image.Size);
            using (var context = UIGraphics.GetCurrentContext())
            {
                if (image.Orientation == UIImageOrientation.Right || image.Orientation == UIImageOrientation.Left)
                {
                    context.ScaleCTM(-1, 1);
                    context.TranslateCTM(-image.Size.Height, 0);
                }
                else
                {
                    context.ScaleCTM(1, -1);
                    context.TranslateCTM(0, -image.Size.Height);
                }

                context.ConcatCTM(transform);
                if (drawImageSize is CGSize size)
                {
                    context.DrawImage(new CGRect(0, 0, size.Width, size.Height), image.CGImage);
                }
                else
                {
                    context.DrawImage(new CGRect(0, 0, image.Size.Width, image.Size.Height), image.CGImage);
                }

                var newImage = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();
                return newImage;
            }
        }
    }
}
