namespace _06_Access_Modifiers
{
    internal class Singer
    {
        private string _name;
        private string _surname;
        private int _age;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length <= 100) _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            { 
                if (value.Length <= 100) _surname = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 170) _age = value; 
            }
        }

        public Singer(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

    }

    internal class Song
    {
        private string _name;
        private string _genre;
        private Singer _singer;
        private double[] _ratings;

        public string Name
        {
            get { return _name; }
            set
            { 
                if (value.Length <= 100) _name = value;
            }
        }

        public string Genre
        {
            get { return _genre; }
            set
            {
                if (value == "Pop" || value == "Rock" || value == "Jazz" || value == "Techno") _genre = value;
            }
        }

        public Singer Singer
        { 
            get { return _singer; }
            set
            {
                if (value is Singer) _singer = value;
            }
        }

        public Song(string name, string genre, Singer singer)
        {
            Name = name;
            Genre = genre;
            Singer = singer;
            _ratings = new double[0];
        }

        public void AddRating(double rating)
        {
            if (rating < 0 || rating > 10)
            {
                return;
            }
            Array.Resize(ref _ratings, _ratings.Length + 1);
            _ratings[_ratings.Length - 1] = rating;
        }

        public double GetAverageRating()
        {
            double average = 0;
            double sum = 0;
            foreach (double rating in _ratings)
            { 
                sum += rating;
            }
            average = sum / _ratings.Length;

            return average;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Singer\nFull Name: {Singer.Name} {Singer.Surname}\nAge: {Singer.Age}\n");
            Console.WriteLine($"Song\nName: {Name}\nGenre: {Genre}\nRating count: {_ratings.Length}");
            Console.WriteLine($"All ratings: {String.Join(", ", _ratings)}\nAverage Rating: {(float)GetAverageRating()}");
        }
    }
}
