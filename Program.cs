using Gtk;
using System;

class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        // Create a new window
        Window window = new Window("GTK# Widget Showcase");
        window.SetDefaultSize(600, 400);
        window.DeleteEvent += (o, e) => Application.Quit();

        // Create a vertical box container
        VBox vbox = new VBox(false, 5);

        // Add a label
        Label label = new Label("This is a label!");
        vbox.PackStart(label, false, false, 0);

        // Add a button
        Button button = new Button("Click Me");
        button.Clicked += (sender, e) => label.Text = "Button Clicked!";
        vbox.PackStart(button, false, false, 0);

        // Add a text entry with placeholder workaround
        Entry entry = new Entry();
        entry.Text = "Type something here..."; // Set initial placeholder text
        entry.FocusInEvent += (o, e) =>
        {
            if (entry.Text == "Type something here...")
                entry.Text = ""; // Clear placeholder on focus
        };
        entry.FocusOutEvent += (o, e) =>
        {
            if (string.IsNullOrWhiteSpace(entry.Text))
                entry.Text = "Type something here..."; // Reset placeholder on focus out
        };
        vbox.PackStart(entry, false, false, 0);

        // Add a combo box (replacing ComboBoxText)
        ComboBox comboBox = ComboBox.NewText();
        comboBox.AppendText("Option 1");
        comboBox.AppendText("Option 2");
        comboBox.AppendText("Option 3");
        comboBox.Active = 0; // Set default selection
        comboBox.Changed += (sender, e) =>
        {
            label.Text = $"Selected: {comboBox.ActiveText}";
        };
        vbox.PackStart(comboBox, false, false, 0);

        // Add a checkbox
        CheckButton checkButton = new CheckButton("I agree");
        vbox.PackStart(checkButton, false, false, 0);

        // Add a progress bar
        ProgressBar progressBar = new ProgressBar();
        progressBar.Fraction = 0.5; // Set progress to 50%
        vbox.PackStart(progressBar, false, false, 0);

        // Add a toggle button
        ToggleButton toggleButton = new ToggleButton("Toggle Me");
        toggleButton.Toggled += (sender, e) =>
        {
            if (toggleButton.Active)
                toggleButton.Label = "Toggled On";
            else
                toggleButton.Label = "Toggled Off";
        };
        vbox.PackStart(toggleButton, false, false, 0);

        // Add a frame with a nested widget
        Frame frame = new Frame("This is a frame");
        Label frameLabel = new Label("Content inside frame");
        frame.Add(frameLabel);
        vbox.PackStart(frame, false, false, 0);

        // Add the vertical box to the window
        window.Add(vbox);

        // Show all widgets
        window.ShowAll();

        Application.Run();
    }
}
