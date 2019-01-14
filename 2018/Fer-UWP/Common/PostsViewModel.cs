using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Input;

namespace Common
{
    public class Post
    {
        public long UserId { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class PostsViewModel : BaseViewModel
    {
        Post post;
        public Post Post
        {
            get => post;
            set
            {
                post = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoadCommand { get; }

        public PostsViewModel()
        {
            LoadCommand = new Command(Load);
        }

        public async void Load(object o)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
            var post = JsonConvert.DeserializeObject<Post>(json);
            Post = post;
        }
    }
}
