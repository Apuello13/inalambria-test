namespace domino_api.Dto
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginDto(string _Username, string _Password) {
            this.Username = _Username;
            this.Password = _Password;
        }
        public LoginDto() { }
    }
}
