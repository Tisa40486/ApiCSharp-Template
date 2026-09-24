using System.ComponentModel.DataAnnotations.Schema;
using Template.Data.Model;

namespace Template.Model
{
    [Table("Template")]
    public class TemplateDao : IModelDao
    {
        public int Id { get; set; }
        public string Comment { get; set; }
    }
}