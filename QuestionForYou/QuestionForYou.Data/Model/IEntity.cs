using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForYou.Data.Model
{
    public interface IEntity : ICloneable
    {
        int? Id { get; set; }
    }
}
