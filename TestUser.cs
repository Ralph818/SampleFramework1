namespace SampleFramework1
{
    internal class TestUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public TestUser(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
    }
}