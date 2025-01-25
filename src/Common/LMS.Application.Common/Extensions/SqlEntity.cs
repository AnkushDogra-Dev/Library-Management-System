using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LMS.Application.Common.Extensions
{
    class SqlEntity
    {
        /// <summary>
		/// Id of the record.
		/// </summary>
        [Key]
        public int Id {get; set;}
    }
}