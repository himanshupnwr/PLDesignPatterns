﻿namespace State_Design_Pattern.Logic
{
    public abstract class BookingState
    {
        public abstract void EnterState(BookingContext booking);
        public abstract void Cancel(BookingContext booking);
        public abstract void DatePassed(BookingContext booking);
        public abstract void EnterDetails(BookingContext booking, string attendee, int ticketCount);
    }
}
