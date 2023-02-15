using domino_api.Dto;

namespace domino_api.Models
{
    public class User : LoginDto
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public User(int id, string _username, string _password, string _token) {
            this.Id = id;
            this.Username = _username;
            this.Password = _password;
            this.Token = _token;
        }

        public User() { }
    }
}
