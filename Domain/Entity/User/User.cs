﻿using Domain.Entity.Relations;

namespace Domain.Entity;

public class User : BaseEntity
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public ICollection<FavouriteBooks>? FavouriteBooks { get; set; }
    public ICollection<UserBooks>? UserBooks { get; set; }
}
