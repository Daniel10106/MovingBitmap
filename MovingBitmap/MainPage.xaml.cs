using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas.UI;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Windows.UI;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovingBitmap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CanvasBitmap bitmapOrb;
        float xPos = 0.0f;
        float yPos = 0.0f;

        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += ground_KeyDown;
            Windows.UI.Xaml.Media.CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void Ground_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(Ground_CreateResourcesAsync(sender).AsAsyncAction());
        }

        async Task Ground_CreateResourcesAsync(CanvasControl sender)
        {
            bitmapOrb = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/objects/orb.png"));
        }

        private void Ground_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            args.DrawingSession.DrawImage(bitmapOrb, xPos, yPos);

            ground.Invalidate();
        }

        private void ground_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (args.VirtualKey == Windows.System.VirtualKey.A)
            {
                xPos += 20.0f;
            }          
        }

        private void CompositionTarget_Rendering(object sender, object e)
        {
            yPos = (float)bitmapOrb.GetValue(Canvas.TopProperty);
            xPos = (float)bitmapOrb.GetValue(Canvas.LeftProperty);
            moveOrb();
        }

        private void moveOrb()
        {

        }
    }
}
