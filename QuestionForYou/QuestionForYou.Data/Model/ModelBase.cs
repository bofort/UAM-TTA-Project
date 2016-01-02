using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForYou.Data.Model
{
    public abstract class ModelBase : IEntity
    {
        public int? Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
