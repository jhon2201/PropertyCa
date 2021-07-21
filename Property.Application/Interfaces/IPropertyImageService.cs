using Property.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Interfaces
{
    public interface IPropertyImageService
    {
        PropertyImageViewModel GetPropertyImages();
    }
}
