namespace QuizApp.Controllers.Requests
{
    public class LoginRequest
    {
        public string name { get; set;}
        public string email { get; set; }
        public string provider { get; set; }
        public string uid { get; set; }
    }
}
