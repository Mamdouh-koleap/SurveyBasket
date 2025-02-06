namespace SurveyBasket.Api.Mapping
{
    public class MappingConfigyrations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, PollResponse>().TwoWays();
            
        }
    }
}
