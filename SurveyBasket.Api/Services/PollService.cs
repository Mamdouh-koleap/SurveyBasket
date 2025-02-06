
namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {

        private static readonly List<Poll> _polls = 
        [
         new Poll{
             Id = 1,
             Title="poll 1",
             Description="my first poll"
         }

        ];
        public IEnumerable<Poll> GetAll() => _polls;
        public Poll? Get(int id) => _polls.SingleOrDefault(x => x.Id == id);
        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1;
           _polls.Add(poll);  
            return poll;
        }
        public bool Update(int id ,Poll poll)
        {
            var currentPoll=Get(id);
            if (currentPoll == null)
            {
                return false;
            }
            currentPoll.Title = poll.Title;
            currentPoll.Description = poll.Description; 
            return true;    
        }
        public bool Delete(int id)
        {
            var Poll = Get(id);
            if (Poll == null)
            {
                return false;
            }
            _polls.Remove(Poll);
            return true;
        }

    }
}
