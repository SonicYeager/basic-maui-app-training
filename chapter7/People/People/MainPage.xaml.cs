using People.Models;
using System.Collections.Generic;

namespace People;

public sealed partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private async void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        await App.PersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private async void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        var people = await App.PersonRepo.GetAllPeople();
        peopleList.ItemsSource = people;
    }

}