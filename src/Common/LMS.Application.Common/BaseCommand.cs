using System.Text.Json.Serialization;

namespace LMS.Application.Common 
{
	public record BaseCommand 
	{
		/// <summary>
		/// Id of the record.
		/// </summary>
		[JsonIgnore]
		public Guid Id { get; private set; }


		/// <summary>
		/// Method to set Id
		/// </summary>
        public void SetId(Guid id)
		{
			Id = id;
		}
	}
}

