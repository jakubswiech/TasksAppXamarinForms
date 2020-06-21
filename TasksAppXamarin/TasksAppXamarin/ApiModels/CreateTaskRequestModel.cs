namespace TasksAppXamarin.ApiModels
{
    public class CreateTaskRequestModel
    {
        public string Name { get; }
        public string Content { get; }

        public CreateTaskRequestModel(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
