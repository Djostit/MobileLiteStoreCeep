﻿namespace MobileLiteStoreCeep.Views;

public partial class LibraryPage : ContentPage
{
    public LibraryPage(LibraryViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
