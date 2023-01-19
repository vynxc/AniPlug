#if  ANDROID
using Android.Text;
#endif
using AniPlug.Anime.ViewModels;
using AniPlug.API_Wrappers.Consumet;
using CommunityToolkit.Maui;
using JikanDotNet;
using Microsoft.Maui.Handlers;
using SkiaSharp.Views.Maui.Controls.Hosting;
using UraniumUI;

namespace AniPlug;

public static class MauiProgram
{
    public static IJikan jikan = new Jikan();
    public static Consumet Consumet = new();

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureMauiHandlers(handlers => { handlers.AddUraniumUIHandlers(); }).ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-ExtraBold.ttf", "MontserratExtraBold");
                fonts.AddFont("Montserrat-Medium.ttf", "MontserraMedium");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
                fonts.AddFont("BeVietnamPro-Regular.ttf", "BeVietnamPro");


                fonts.AddMaterialIconFonts();
            }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton(typeof(HeroPage));
        builder.Services.AddSingleton(typeof(MainPageViewModel));
        AllowMultiLineTruncationOnAndroid();

        return builder.Build();
    }

    private static void AllowMultiLineTruncationOnAndroid()
    {
#if ANDROID

        /* 
		 * The default Controls handling of LineBreakMode and MaxLines on Android
		 * only allows single lines when using text truncation. However, combining
		 * setMaxLines() and TextUtils.TruncateAt.END _is_ supported on Android 
		 * (see https://developer.android.com/reference/android/widget/TextView#setEllipsize(android.text.TextUtils.TruncateAt))
		 * 
		 * The following code updates the mappings for Label on Android to support
		 * this scenario. Truncation and max lines both affect the platform setting
		 * of maximum lines, so we need to modify the mappings for both properties. 
		 * We append a second mapping that checks for our target situation (end truncation)
		 * and sets the maximum lines to the target value.
		*/

        static void UpdateMaxLines(LabelHandler handler, ILabel label)
        {
            var textView = handler.PlatformView;
            if (label is Label controlsLabel && textView.Ellipsize == TextUtils.TruncateAt.End)
                textView.SetMaxLines(controlsLabel.MaxLines);
        }

        ;

        Label.ControlsLabelMapper.AppendToMapping(
            nameof(Label.LineBreakMode), UpdateMaxLines);

        Label.ControlsLabelMapper.AppendToMapping(
            nameof(Label.MaxLines), UpdateMaxLines);

#endif


#if WINDOWS
        static void UpdateMaxLines(Microsoft.Maui.Handlers.LabelHandler handler, ILabel label)
        {
            var textView = handler.PlatformView;
            if (label is Label controlsLabel && textView.TextTrimming == Microsoft.UI.Xaml.TextTrimming.CharacterEllipsis)
            {
                textView.MaxLines = controlsLabel.MaxLines;
            }

            Label.ControlsLabelMapper.AppendToMapping(
               nameof(Label.LineBreakMode), UpdateMaxLines);

            Label.ControlsLabelMapper.AppendToMapping(
                nameof(Label.MaxLines), UpdateMaxLines);
        }
#endif
    }
}