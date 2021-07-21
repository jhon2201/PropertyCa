using Property.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Interfaces
{
    public interface IPropertyImage
    {
        IEnumerable<PropertyImage> GetPropertyImages();
    }
}
