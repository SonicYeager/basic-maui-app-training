namespace Notes;

public partial class MainPage : ContentPage
{
    private readonly string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public MainPage()
    {
        InitializeComponent();

        if (File.Exists(_fileName)) Editor.Text = File.ReadAllText(_fileName);
    }

    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, Editor.Text);
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName)) File.Delete(_fileName);
        Editor.Text = string.Empty;
    }
}