using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    /// <summary>
    /// Model of the object Book to be created in a database.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Book Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Book Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Book DisplayOrder
        /// </summary>
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Value should be between 1 and 100!")]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Time book was created.
        /// </summary>
        public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    }
}
