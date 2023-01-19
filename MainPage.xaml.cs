using AniPlug.Anime.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Text.Json;
using RestSharp;
using JikanDotNet;
using UraniumUI.Pages;
using System.Diagnostics;
using AniPlug.Anime.ViewModels;

namespace AniPlug;

public partial class MainPage : ContentPage
{


    

    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    
     
}

