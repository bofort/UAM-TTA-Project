using System;

namespace QuestionForYou.Data.Model
{
    public interface IEntity : ICloneable
    {
        int? Id { get; set; }
    }
}