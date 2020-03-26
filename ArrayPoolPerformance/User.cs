namespace ArrayPoolPerformance
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public byte[] Avatar { get; set; }

        public User()
        {
            this.Age = 22;
            this.Email = "dummy@test.com";
            this.Name = "Dunny name";
            this.Avatar = new byte[1000000];
        }
    }
}
