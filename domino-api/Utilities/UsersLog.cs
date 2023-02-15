using domino_api.Models;

namespace domino_api.Utilities
{
    public class UsersLog
    {
        public List<User> users = new List<User>();

        public UsersLog() {
            users.Add(new User(1, "developer", "inalambria2023*", ""));
        }

        public List<User> getUsers() {
            return this.users;
        }
    }
}
