private List<string> _locations = new List<string>(); //_locations  are somwhere populated

executeTextBox.Clear(); // out TextBox

//First option, no string configuration availivility
executeTextBox.Text = String.Join(Environment.NewLine, _locations); //Firs

foreach (var location in _locations)
{
    //Second option
    executeTextBox.Text += location.Substring(0, location.Length - 1) + '\n';

    //The third option recommended by https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox, Accessed 27.05.2020
    executeTextBox.AppendText(location.Substring(0, location.Length - 1));
    executeTextBox.AppendText(Environment.NewLine);
}
