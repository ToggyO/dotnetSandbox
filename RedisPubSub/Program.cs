// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using StackExchange.Redis;

Console.WriteLine("Redis Pub/Sub!");

const string ChannelName = "feeds";

var connection = ConnectionMultiplexer.Connect(
    "apollords.redis.cache.windows.net:6380,password=PAEcN8KUzE7fVtFllqkVAWOwHKO32PlFhAzCaEruGLw=,ssl=True,abortConnect=False");
var subscriber = connection.GetSubscriber();

await subscriber.SubscribeAsync(ChannelName, (channel, message) =>
{
    Console.WriteLine("Channel: {0}", channel.ToString());
    var content = JsonSerializer.Deserialize<FeedDto>(message);
    
    Console.WriteLine("Message:");
    foreach (var feed in content.FeedData)
    {
        Console.WriteLine("Post Id: {0}, Created At: {1}", feed.PostId, feed.CreatedDate);
        Console.WriteLine("=====> Interests:");
        foreach (var interest in feed.InterestsList)
            Console.WriteLine("=========> {0}", interest);
    }
});

Console.ReadKey();

public class FeedDto
{
    public IEnumerable<FeedData> FeedData { get; set; }
}

public class FeedData
{
    public int PostId { get; set; }

    // TODO: check this solution
    [System.Text.Json.Serialization.JsonIgnore]
    public int InterestId
    {
        get => InterestsList.Length > 0 ? InterestsList[0] : default;
        set { InterestsList = new int[] { value }; }
    }

    // TODO: check this solution
    public int[] InterestsList { get; set; } = new int[] {};
    // public int[] InterestsList
    // {
    //     get => new int[] { InterestId };
    //     set => _interestsList = value;
    // }

    public int CreatorUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? TotalLikes { get; set; }

    public int? TotalViews { get; set; }

    public int? TotalComments { get; set; }

    // public int? TotalNegativeComments { get; set; }

    public int? TotalUpVote { get; set; }

    public int? TotalDownVote { get; set; }
}

// public class FeedData
// {
//     // TODO: check this solution
//     private int[] _interestsList = new int[] {};
//
//     public int PostId { get; set; }
//
//     // TODO: check this solution
//     [System.Text.Json.Serialization.JsonIgnore]
//     public int InterestId { get; set; }
//
//     // TODO: check this solution
//     public int[] InterestsList
//     {
//         get => new int[] { InterestId };
//         set => _interestsList = value;
//     }
//
//     public int CreatorUserId { get; set; }
//
//     public DateTime CreatedDate { get; set; }
//
//     public int? TotalLikes { get; set; }
//
//     public int? TotalViews { get; set; }
//
//     public int? TotalComments { get; set; }
//
//     // public int? TotalNegativeComments { get; set; }
//
//     public int? TotalUpVote { get; set; }
//
//     public int? TotalDownVote { get; set; }
// }