namespace _08_Exception;

class Meeting
{
    private DateTime _toDate;
    public DateTime FromDate { get; set; }
    public DateTime ToDate 
    {
        get => _toDate;
        set
        {
            if (value <= FromDate)
                throw new WrongDateIntervalException("To date can not be less than from date!");
            else
            { 
                _toDate = value;
            }
        }
    }
    public string Name { get; set; }

    public Meeting(string name, DateTime from, DateTime to)
    {
        Name = name;
        FromDate = from;
        ToDate = to;
    }

    public override string ToString()
    {
        return $"{this.GetType().ToString().Split('.')[^1]} {{ Name: {Name}, From: {FromDate.Date}, To: {ToDate.Date} }}";
    }
}

class MeetingSchedule
{
    private Meeting[] _meetings = new Meeting[0];
    public Meeting[] Meetings { get => _meetings; } 

    public void SetMeeting(string name, DateTime from, DateTime to)
    {
        bool isFrom = false;
        bool isTo = false;
        foreach (Meeting meeting in Meetings)
        {
            isFrom = from >= meeting.FromDate && meeting.ToDate >= from;
            isTo = to >= meeting.FromDate && meeting.ToDate >= to;
            if (isFrom || isTo)
                throw new ReservedDateIntervalException($"We already have meeting for this time: {{ Name: {meeting.Name}, From: {meeting.FromDate.Date}, To: {meeting.ToDate.Date} }}");
        }

        Meeting newMeeting = new(name, from, to);
        Array.Resize(ref _meetings, _meetings.Length + 1);
        _meetings[_meetings.Length - 1] = newMeeting;
    }
}

class ReservedDateIntervalException : Exception
{
    public ReservedDateIntervalException(string message) : base(message) { }
}

class WrongDateIntervalException : Exception
{
    public WrongDateIntervalException(string message) : base(message) { }
}
