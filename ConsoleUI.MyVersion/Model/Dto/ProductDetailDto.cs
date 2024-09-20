using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.MyVersion.Model.Dto;

public record ProductDetailDto
    (
    int Id,
    string CategoryName,
    string Name,
    double Price,
    int Stock
    );

