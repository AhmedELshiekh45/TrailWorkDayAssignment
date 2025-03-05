namespace Domain.DTOS
{
    public class StudentDto
    {
        private static int _nextId = 1; // عداد لتوليد الـ Id

        public int Id { get; set; } = _nextId++; // توليد الـ Id تلقائيًا
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public int Age { get; set; }
    }
}
