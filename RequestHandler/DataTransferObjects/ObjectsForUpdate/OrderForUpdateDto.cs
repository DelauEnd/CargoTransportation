using System.ComponentModel.DataAnnotations;

namespace RequestHandler.ObjectsForUpdate
{
    public class OrderForUpdateDto
    {
        public int SenderId { get; set; }

        public int DestinationId { get; set; }

        [EnumDataType(typeof(Status))]
        public string Status { get; set; }
    }
}
