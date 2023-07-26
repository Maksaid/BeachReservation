﻿namespace Presentation.Models;

public record CreateBeachModel(string Name, string Description, int RowsCount, int ColsCount, string Country, string City, string Longitude, string Latitude){}