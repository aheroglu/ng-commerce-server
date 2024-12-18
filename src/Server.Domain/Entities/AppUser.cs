using Microsoft.AspNetCore.Identity;

namespace Server.Domain.Entities;

public sealed class AppUser : IdentityUser
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string FullName { get; set; } = default!;
    public DateOnly BirthDate { get; set; }
    public bool IsBlocked { get; set; } = false;

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();
}
